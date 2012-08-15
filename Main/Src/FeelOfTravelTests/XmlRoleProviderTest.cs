using FeelOfTravel.Logic.Providers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;

namespace FeelOfTravelTests
{
    using System.Collections.Specialized;
    using System.Xml;
    using System.Xml.Linq;

    using FeelOfTravelTests.Utils;

    /// <summary>
    ///This is a test class for XmlRoleProviderTest and is intended
    ///to contain all XmlRoleProviderTest Unit Tests
    ///</summary>
    [TestClass()]
    public class XmlRoleProviderTest
    {
        private string path;
        
        /// <summary>
        ///A test for AddUsersToRoles
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost/FeelOfTravel")]
        public void AddUsersToRolesTest()
        {
            using (var docPreserver = new XDocumentPreserver(ProviderHelper.TEST_XML_PATH))
            {

                XmlRoleProvider target = this.MakeProvider(); // TODO: Initialize to an appropriate value
                string[] usernames = new[] { "Roman" }; // TODO: Initialize to an appropriate value
                string[] roleNames = new[] { "Admins", "Editors" }; // TODO: Initialize to an appropriate value

                Assert.IsFalse(target.IsUserInRole("Roman", "Admins"));
                Assert.IsTrue(target.IsUserInRole("Roman", "Editors"));

                target.AddUsersToRoles(usernames, roleNames);

                Assert.IsTrue(target.IsUserInRole("Roman", "Admins"));
                Assert.IsTrue(target.IsUserInRole("Roman", "Editors"));
            }
        }

        private XmlRoleProvider MakeProvider()
        {
            XmlRoleProvider provider = new XmlRoleProvider();
            NameValueCollection config = new NameValueCollection();
            config.Add("fileName", ProviderHelper.TEST_XML_PATH);
            provider.Initialize("Test role provider",config);

            return provider;
        }

        /// <summary>
        ///A test for CreateRole
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost/FeelOfTravel")]
        public void CreateRoleTest()
        {
            using (var docPreserver = new XDocumentPreserver(ProviderHelper.TEST_XML_PATH))
            {
                const string NEW_ROLE = "New Role";
                XmlRoleProvider target = this.MakeProvider(); // TODO: Initialize to an appropriate value
                string roleName = NEW_ROLE; // TODO: Initialize to an appropriate value
                target.CreateRole(roleName);

                Assert.IsTrue(target.RoleExists(NEW_ROLE));
            }
        }

        /// <summary>
        ///A test for DeleteRole
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost/FeelOfTravel")]
        public void DeleteRoleTest()
        {
using (var docPreserver = new XDocumentPreserver(ProviderHelper.TEST_XML_PATH))
            {
                XmlRoleProvider target = this.MakeProvider(); // TODO: Initialize to an appropriate value
                
                Assert.IsTrue(target.RoleExists("Admins"));
                target.DeleteRole("Admins", false);
                Assert.IsFalse(target.RoleExists("Admins"));
            }
        }

        /// <summary>
        ///A test for FindUsersInRole
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost/FeelOfTravel")]
        public void FindUsersInRoleTest()
        {
            XmlRoleProvider target = this.MakeProvider(); // TODO: Initialize to an appropriate value
            string roleName = "Admins"; // TODO: Initialize to an appropriate value
            string usernameToMatch = "dmi"; // *dmi* -> Admin
            string[] expected = new[] {"Admin"}; // TODO: Initialize to an appropriate value
            string[] actual = target.FindUsersInRole(roleName, usernameToMatch);
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetAllRoles
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost/FeelOfTravel")]
        public void GetAllRolesTest()
        {
            XmlRoleProvider target = this.MakeProvider(); // TODO: Initialize to an appropriate value
            string[] expected = new string[]{"Admins", "Editors", "Guests"}; // TODO: Initialize to an appropriate value
            string[] actual;
            actual = target.GetAllRoles();
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetRolesForUser
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost/FeelOfTravel")]
        public void GetRolesForUserTest()
        {
            XmlRoleProvider target = this.MakeProvider(); // TODO: Initialize to an appropriate value
            string username = "Roman"; // TODO: Initialize to an appropriate value
            string[] expected = new[] {"Editors"}; // TODO: Initialize to an appropriate value
            string[] actual;
            actual = target.GetRolesForUser(username);
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetUsersInRole
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost/FeelOfTravel")]
        public void GetUsersInRoleTest()
        {
            string path = string.Empty; // TODO: Initialize to an appropriate value
            XmlRoleProvider target = this.MakeProvider(); // TODO: Initialize to an appropriate value
            string roleName = "Admins"; // TODO: Initialize to an appropriate value
            string[] expected = new[]{"Admin"}; // TODO: Initialize to an appropriate value
            string[] actual;
            actual = target.GetUsersInRole(roleName);
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for IsUserInRole
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost/FeelOfTravel")]
        public void IsUserInRoleTest()
        {
            XmlRoleProvider target = this.MakeProvider(); // TODO: Initialize to an appropriate value
            
            //check existing users and roles
            Assert.IsTrue(target.IsUserInRole("Admin", "Admins"));

            Assert.IsFalse(target.IsUserInRole("Unknown", "Guests"));
            Assert.IsFalse(target.IsUserInRole("Admin", "Guests"));

            //do the same for non existing users/roles
        }

        /// <summary>
        ///A test for RemoveUsersFromRoles
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost/FeelOfTravel")]
        public void RemoveUsersFromRolesTest()
        {
            using (var docPreserver = new XDocumentPreserver(ProviderHelper.TEST_XML_PATH))
            {
                XmlRoleProvider target = this.MakeProvider(); // TODO: Initialize to an appropriate value
                string[] usernames = new[] { "Admin" }; // TODO: Initialize to an appropriate value
                string[] roleNames = new[] { "Admins" }; // TODO: Initialize to an appropriate value

                target.RemoveUsersFromRoles(usernames, roleNames);

                Assert.IsFalse(target.IsUserInRole("Admin", "Admins"));
            }
        }

        /// <summary>
        ///A test for RoleExists
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost/FeelOfTravel")]
        public void RoleExistsTest()
        {
            XmlRoleProvider target = this.MakeProvider(); // TODO: Initialize to an appropriate value
            Assert.IsTrue(target.RoleExists("Admins"));
            Assert.IsFalse(target.RoleExists("NonExistingRole"));
        }
    }
}
