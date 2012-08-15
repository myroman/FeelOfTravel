using System;
using System.Collections.Generic;
using System.Linq;

namespace FeelOfTravel.Logic.Providers
{
    using System.Xml.Linq;

    public class SecurityXmlHelper
    {
        private readonly string xmlPath;

        private XDocument _doc;

        public SecurityXmlHelper(string xmlPath)
        {
            this.xmlPath = xmlPath;

            _doc = XDocument.Load(this.xmlPath);
        }

        public bool UserExists(string userName)
        {
            var descs = this.GetUserElements(element => GetUserName(element) == userName);

            return descs.Any();
        }

        public delegate bool ElementFilterPredicate(XElement element);

        public XElement[] GetUserElements(ElementFilterPredicate filterPredicate)
        {
            return _doc.Root.Descendants(XName.Get("users")).SingleOrDefault().Descendants(XName.Get("user")).Where(xElem => filterPredicate(xElem)).ToArray();
        }

        public XElement GetUserElementByUserName(string userName)
        {
            return this.GetUserElements(element => GetUserName(element).Equals(userName, StringComparison.InvariantCultureIgnoreCase)).SingleOrDefault();
        }

        public XElement GetUserElementByEmail(string email)
        {
            return this.GetUserElements(element => element.Attribute(XName.Get("email")).Value.Equals(email, StringComparison.InvariantCultureIgnoreCase)).SingleOrDefault();
        }

        public XElement GetUserElementByKey(object key)
        {
            return this.GetUserElements(element => element.Attribute(XName.Get("key")).Value.Equals(key.ToString(), StringComparison.InvariantCultureIgnoreCase)).SingleOrDefault();
        }

        public bool RoleExists(string roleName)
        {
            return this.GetRoleElements(roleName).Any();
        }

        public XElement[] GetRoleElements()
        {
            return this.GetRoleElements(element => true);
        }

        public XElement[] GetRoleElements(string roleName)
        {
            return this.GetRoleElements(element => GetRoleName(element) == roleName);
        }

        public XElement[] GetRoleElements(ElementFilterPredicate filterPredicate)
        {
            return RolesElement.Descendants(XName.Get("role")).Where(xElem => filterPredicate(xElem)).ToArray();
        }

        public XElement RolesElement
        {
            get
            {
                return _doc.Root.Descendants(XName.Get("roles")).SingleOrDefault();
            }
        }

        public XElement UsersElement
        {
            get
            {
                return _doc.Root.Descendants(XName.Get("users")).SingleOrDefault();
            }
        }

        public void Save()
        {
            _doc.Save(this.xmlPath);
        }

        public static string GetUserName(XElement userElement)
        {
            return userElement.Attribute(XName.Get("userName")).Value;
        }

        public static string GetUserPassword(XElement userElement)
        {
            return userElement.Attribute(XName.Get("password")).Value;
        }

        public static string GetRoleName(XElement roleElement)
        {
            return roleElement.Attribute(XName.Get("roleName")).Value;
        }

        public static XElement[] GetUsersInRole(XElement roleElement)
        {
            return roleElement.Elements(XName.Get("user")).ToArray();
        }

        public static string GetUserReferenceName(XElement userElement)
        {
            return userElement.Value;
        }

        public static void AddAttributeToElement(XElement parent, string attributeName, string attributeValue)
        {
            parent.SetAttributeValue(XName.Get(attributeName), attributeValue);
        }
    }
}