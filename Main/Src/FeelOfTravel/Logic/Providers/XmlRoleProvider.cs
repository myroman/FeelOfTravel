using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Xml.Linq;

namespace FeelOfTravel.Logic.Providers
{
    public class XmlRoleProvider : RoleProvider
    {
        private SecurityXmlHelper xmlHelper;

        public override void Initialize(string name, System.Collections.Specialized.NameValueCollection config)
        {
            base.Initialize(name, config);

            string fileName;

            if(HttpContext.Current != null)
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

        public override bool IsUserInRole(string userName, string roleName)
        {
            if(!this.xmlHelper.UserExists(userName))
            {
                throw new ArgumentException("User does not exist!");
            }

            if (!this.xmlHelper.RoleExists(roleName))
            {
                throw new ArgumentException("Role does not exist!");
            }
            
            var role = this.xmlHelper.GetRoleElements(roleName).SingleOrDefault();

            return SecurityXmlHelper.GetUsersInRole(role).Where(element => element.Value == userName).Any();
        }

        public override string[] GetRolesForUser(string username)
        {
            List<string> allowedRoles = new List<string>();
            foreach (var roleElement in this.xmlHelper.GetRoleElements())
            {
                var roleUserQuery = SecurityXmlHelper.GetUsersInRole(roleElement);
                if(roleUserQuery.Any(userElement=>userElement.Value.ToUpper() == username.ToUpper()))
                {
                    allowedRoles.Add(SecurityXmlHelper.GetRoleName(roleElement));
                }
            }

            return allowedRoles.ToArray();
        }

        public override void CreateRole(string roleName)
        {
            XElement roleElement = new XElement(XName.Get("role"));
            roleElement.SetAttributeValue(XName.Get("roleName"), roleName);

            this.xmlHelper.RolesElement.Add(roleElement);
            this.xmlHelper.Save();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            var roles = this.xmlHelper.GetRoleElements(roleName);
            if(throwOnPopulatedRole)
            {
                //if (roles.Any(roleElement => roleElement.Elements(XName.Get("user")))) 
                //    throw new ProviderException("Role is not empty!");
            }
            foreach (var roleElement in roles)
            {
                roleElement.Remove();
            }

            this.xmlHelper.Save();
            return true;
        }

        public override bool RoleExists(string roleName)
        {
            return this.xmlHelper.GetRoleElements(roleName).Any();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            if ((usernames == null) || (roleNames == null)) return;

            var existingUsersQuery = this.xmlHelper.GetUserElements(element => usernames.Contains(SecurityXmlHelper.GetUserName(element)));
            var existingRolesQuery = this.xmlHelper.GetRoleElements(element => roleNames.Contains(SecurityXmlHelper.GetRoleName(element)));

            foreach (var role in existingRolesQuery)
            {
                string roleName = SecurityXmlHelper.GetRoleName(role);
                foreach (var user in existingUsersQuery)
                {
                    //add all users to this role if they haven't been added yet.
                    if (!this.IsUserInRole(SecurityXmlHelper.GetUserName(user), roleName))
                    {
                        XElement userReference = new XElement(XName.Get("user"));
                        userReference.Value = SecurityXmlHelper.GetUserName(user);

                        role.Add(userReference);
                    }
                }
            }
            this.xmlHelper.Save();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            if((usernames == null)||(roleNames == null)) return;

            //for each role do:
            //check if current user is in role, if yes then remove him

            var existingUsersQuery = this.xmlHelper.GetUserElements(element => usernames.Contains(SecurityXmlHelper.GetUserName(element)));
            var existingRolesQuery = this.xmlHelper.GetRoleElements(element => roleNames.Contains(SecurityXmlHelper.GetRoleName(element)));

            foreach (var role in existingRolesQuery)
            {
                var roleName = SecurityXmlHelper.GetRoleName(role);
                foreach (var user in existingUsersQuery.
                    Where(user => this.IsUserInRole(SecurityXmlHelper.GetUserName(user), roleName)))
                {
                    var userReference = SecurityXmlHelper.GetUsersInRole(role).
                        Where(userElement =>
                        {
                            return SecurityXmlHelper.GetUserReferenceName(userElement).Equals(SecurityXmlHelper.GetUserName(user), StringComparison.InvariantCultureIgnoreCase);
                        }).
                        SingleOrDefault();
                    userReference.Remove();
                }
            }

            this.xmlHelper.Save();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            return GetUsersInRole(roleName, element => true);
        }
        
        public override string[] GetAllRoles()
        {
            return this.xmlHelper.GetRoleElements().Select(el => SecurityXmlHelper.GetRoleName(el)).ToArray();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            return GetUsersInRole(roleName, element => element.Value.IndexOf(usernameToMatch.ToUpper(), System.StringComparison.InvariantCultureIgnoreCase) > 0);
        }

        private string[] GetUsersInRole(string roleName, SecurityXmlHelper.ElementFilterPredicate userFilter)
        {
            var role = xmlHelper.GetRoleElements(roleName).SingleOrDefault();
            
            return SecurityXmlHelper.GetUsersInRole(role).
                Where(userName => userFilter(userName)).
                Select(userElement => userElement.Value).
                ToArray();
        }

        public override string ApplicationName { get; set; }
        
    }
}