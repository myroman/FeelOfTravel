using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FeelOfTravel.Logic.Providers
{
    using System.Configuration.Provider;
    using System.Security.Cryptography;
    using System.Text;
    using System.Web.Security;
    using System.Xml.Linq;

    public class XmlMembershipProvider : MembershipProvider
    {
        private SecurityXmlHelper xmlHelper;

        public XmlMembershipProvider() : base() {
        }

        public override void Initialize(string name, System.Collections.Specialized.NameValueCollection config)
        {
            base.Initialize(name, config);

            string fileName;

            if (HttpContext.Current != null)
            {
                string serverDataPath = HttpContext.Current.Server.MapPath("~/App_Data/");
                fileName = serverDataPath + config["fileName"];
            }
            else
            {
                //test is being performed
                fileName = config["fileName"];
            }


            this.xmlHelper = new SecurityXmlHelper(fileName);
        }

        #region Helpers
        private MembershipUserCollection GetUsers(SecurityXmlHelper.ElementFilterPredicate evalDelegate,
            int pageIndex, int pageSize, out int totalRecords)
        {
            XElement[] userElements = xmlHelper.GetUserElements(evalDelegate);

            totalRecords = userElements.Length;
            MembershipUserCollection users = new MembershipUserCollection();

            int start = pageIndex * pageSize;
            int end = start + pageSize;

            if (start >= userElements.Length)
                return users;

            for (int i = 0; i < userElements.Length; i++)
            {
                users.Add(GetUserFromElement(userElements[i]));
            }

            return users;
        }
        private MembershipUser GetUserFromElement(XElement userElement)
        {
            if (userElement == null)
                return null;

            string userName = SecurityXmlHelper.GetUserName(userElement);
            Guid userKey = new Guid(userElement.Attribute(XName.Get("key")).Value);
            string email = userElement.Attribute(XName.Get("email")).Value;
            bool approved = bool.Parse(userElement.Attribute(XName.Get("approved")).Value);
            DateTime createDate = DateTime.Parse(userElement.Attribute(XName.Get("createDate")).Value);
            DateTime lastLogin = DateTime.Parse(userElement.Attribute(XName.Get("lastLogin")).Value);

            return new MembershipUser(this.Name, userName, userKey, email, "", "", approved, false, createDate, lastLogin, lastLogin, createDate, createDate);
        }
        public string EncodePassword(string password)
        {
            string encodedPassword = password;
            HMACSHA1 hash = new HMACSHA1();
            hash.Key = new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 };
            encodedPassword = Convert.ToBase64String(hash.ComputeHash(Encoding.Unicode.GetBytes(password)));
            return encodedPassword;
        }
        #endregion

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            ValidatePasswordEventArgs args = new ValidatePasswordEventArgs(username, password, true);
            this.OnValidatingPassword(args);

            if (args.Cancel)
            {
                status = MembershipCreateStatus.InvalidPassword;
                return null;
            }

            if (!string.IsNullOrEmpty(this.GetUserNameByEmail(email)))
            {
                status = MembershipCreateStatus.DuplicateEmail;
                return null;
            }

            if (GetUser(username, false) != null)
            {
                status = MembershipCreateStatus.DuplicateUserName;
                return null;
            }

            if (providerUserKey == null)
            {
                providerUserKey = Guid.NewGuid();
            }
            else if (!(providerUserKey is Guid))
            {
                status = MembershipCreateStatus.InvalidProviderUserKey;
                return null;
            }

            XElement newUserElement = new XElement(XName.Get("user"));
            SecurityXmlHelper.AddAttributeToElement(newUserElement, "userName", username);
            SecurityXmlHelper.AddAttributeToElement(newUserElement, "password", this.EncodePassword(password));
            SecurityXmlHelper.AddAttributeToElement(newUserElement, "key", providerUserKey.ToString());
            SecurityXmlHelper.AddAttributeToElement(newUserElement, "email", email);
            SecurityXmlHelper.AddAttributeToElement(newUserElement, "lastLogin", DateTime.Now.ToString());
            SecurityXmlHelper.AddAttributeToElement(newUserElement, "createDate", DateTime.Now.ToString());
            SecurityXmlHelper.AddAttributeToElement(newUserElement, "approved", isApproved.ToString());

            xmlHelper.UsersElement.Add(newUserElement);

            xmlHelper.Save();
            status = MembershipCreateStatus.Success;
            return GetUser(username, false);
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            return true;
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            XElement el = xmlHelper.GetUserElementByUserName(username);
            if (SecurityXmlHelper.GetUserPassword(el) != EncodePassword(oldPassword))
            {
                return false;
            }

            ValidatePasswordEventArgs args = new ValidatePasswordEventArgs(username, newPassword, true);
            OnValidatingPassword(args);

            if (args.Cancel)
            {
                return false;
            }

            el.Attribute(XName.Get("password")).Value = EncodePassword(newPassword);
            xmlHelper.Save();
            return true;
        }

        public override string ResetPassword(string username, string answer)
        {
            XElement el = xmlHelper.GetUserElementByUserName(username);
            string randomPassword = "[random]";
            el.SetAttributeValue(XName.Get("password"), EncodePassword(randomPassword));
            xmlHelper.Save();
            return randomPassword;
        }

        public override void UpdateUser(MembershipUser user)
        {
            XElement userElement = xmlHelper.GetUserElementByKey(user.ProviderUserKey);
            XElement emailUserElement = xmlHelper.GetUserElementByEmail(user.Email);

            if (emailUserElement != null)
            {
                if (emailUserElement.Element(XName.Get("key")).Value != userElement.Element(XName.Get("key")).Value)
                {
                    throw new ProviderException("E-mail adress already taken");
                }
            }

            userElement.SetAttributeValue(XName.Get("email"), user.Email);
            userElement.SetAttributeValue(XName.Get("approved"), user.IsApproved.ToString());
            xmlHelper.Save();
        }

        public override bool ValidateUser(string username, string password)
        {
            XElement user = xmlHelper.GetUserElementByUserName(username);
            if (user == null) return false;
            if (SecurityXmlHelper.GetUserPassword(user) != this.EncodePassword(password)) return false;
            user.SetAttributeValue(XName.Get("lastLogin"), DateTime.Now.ToString());

            xmlHelper.Save();
            return true;
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            var userElement = xmlHelper.GetUserElementByKey(providerUserKey);
            if (userElement == null) return null;
            return this.GetUserFromElement(userElement);
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            var userElement = xmlHelper.GetUserElementByUserName(username);
            if (userElement == null) return null;
            return this.GetUserFromElement(userElement);
        }

        public override string GetUserNameByEmail(string email)
        {
            XElement[] userElements = xmlHelper.GetUserElements(el => el.Attribute(XName.Get("email")).Value.
                Equals(email, StringComparison.InvariantCultureIgnoreCase));
            if (userElements.Length == 0)
                return "";

            return SecurityXmlHelper.GetUserName(userElements[0]);
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            XElement userElement = xmlHelper.GetUserElementByUserName(username);
            userElement.Remove();
            xmlHelper.Save();
            return true;
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            MembershipUserCollection users = GetUsers(el => true, pageIndex, pageSize, out totalRecords);
            return users;
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            MembershipUserCollection users = GetUsers(el => SecurityXmlHelper.GetUserPassword(el).
                Equals(usernameToMatch, StringComparison.InvariantCultureIgnoreCase), 
                pageIndex, pageSize, out totalRecords);
            return users;
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            MembershipUserCollection users = GetUsers(el => el.Attribute(XName.Get("email")).Value.
                Equals(emailToMatch, StringComparison.InvariantCultureIgnoreCase), 
                pageIndex, pageSize, out totalRecords);
            return users;
        }

        public override bool EnablePasswordRetrieval
        {
            get
            {
                return false;
            }
        }

        public override bool EnablePasswordReset
        {
            get
            {
                return true;
            }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { return false; }
        }

        public override string ApplicationName { get; set; }

        public override int MaxInvalidPasswordAttempts
        {
            get
            {
                return 0;
            }
        }

        public override int PasswordAttemptWindow
        {
            get
            {
                return 0;
            }
        }

        public override bool RequiresUniqueEmail
        {
            get
            {
                return true;
            }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { return MembershipPasswordFormat.Hashed; }
        }

        public override int MinRequiredPasswordLength
        {
            get { return 0; }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get
            {
                return 0;
            }
        }

        public override string PasswordStrengthRegularExpression
        {
            get
            {
                return string.Empty;
            }
        }
    }
}