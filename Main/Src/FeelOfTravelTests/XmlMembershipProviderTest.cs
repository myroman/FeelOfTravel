using FeelOfTravel.Logic.Providers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System.Web.Security;
using System.Xml.Linq;
using System.Collections.Specialized;

namespace FeelOfTravelTests
{
    using FeelOfTravelTests.Utils;

    /// <summary>
    ///This is a test class for XmlMembershipProviderTest and is intended
    ///to contain all XmlMembershipProviderTest Unit Tests
    ///</summary>
    [TestClass()]
    public class XmlMembershipProviderTest
    {

        /// <summary>
        ///A test for ChangePassword
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost/FeelOfTravel")]
        public void ChangePasswordTest()
        {
            using (new XDocumentPreserver(ProviderHelper.TEST_XML_PATH))
            {
                XmlMembershipProvider target = MakeXmlMembershipProvider(); // TODO: Initialize to an appropriate value
                string p1 = target.EncodePassword("p1");
                string p2 = target.EncodePassword("p2");
                Assert.IsTrue(target.ChangePassword("Roman", "p1", "p2"));
            }
        }

        private static XmlMembershipProvider MakeXmlMembershipProvider()
        {
            NameValueCollection config = new NameValueCollection();
            config.Add("fileName", ProviderHelper.TEST_XML_PATH);

            var provider = new XmlMembershipProvider();
            provider.Initialize("XmlMembershipProvider", config);
            return provider;
        }

        /// <summary>
        ///A test for ChangePasswordQuestionAndAnswer
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost/FeelOfTravel")]
        public void ChangePasswordQuestionAndAnswerTest()
        {
            using (var docPreserver = new XDocumentPreserver(ProviderHelper.TEST_XML_PATH))
            {
                XmlMembershipProvider target = MakeXmlMembershipProvider(); // TODO: Initialize to an appropriate value
                Assert.IsTrue(target.ChangePasswordQuestionAndAnswer("", "", "", ""));
            }
        }

        /// <summary>
        ///A test for CreateUser
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost/FeelOfTravel")]
        public void CreateUserTest()
        {
            using (var docPreserver = new XDocumentPreserver(ProviderHelper.TEST_XML_PATH))
            {
                XmlMembershipProvider target = MakeXmlMembershipProvider(); // TODO: Initialize to an appropriate value
                string username = "NewUser"; // TODO: Initialize to an appropriate value
                string password = "p1"; // TODO: Initialize to an appropriate value
                string email = "NewUser@test.com"; // TODO: Initialize to an appropriate value
                string passwordQuestion = string.Empty; // TODO: Initialize to an appropriate value
                string passwordAnswer = string.Empty; // TODO: Initialize to an appropriate value
                bool isApproved = true; // TODO: Initialize to an appropriate value
                object providerUserKey = null; // TODO: Initialize to an appropriate value
                MembershipCreateStatus status = new MembershipCreateStatus(); // TODO: Initialize to an appropriate value
                MembershipUser actual;
                
                actual = target.CreateUser(username, password, email, passwordQuestion, passwordAnswer, isApproved, providerUserKey, out status);

                Assert.AreEqual("NewUser", actual.UserName);
                Assert.AreEqual("p1", actual.GetPassword());

            }
        }

        /// <summary>
        ///A test for DeleteUser
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost/FeelOfTravel")]
        public void DeleteUserTest()
        {
            using (var docPreserver = new XDocumentPreserver(ProviderHelper.TEST_XML_PATH))
            {
                XmlMembershipProvider target = MakeXmlMembershipProvider(); // TODO: Initialize to an appropriate value
                string username = string.Empty; // TODO: Initialize to an appropriate value
                bool deleteAllRelatedData = false; // TODO: Initialize to an appropriate value
                bool expected = false; // TODO: Initialize to an appropriate value
                bool actual;
                actual = target.DeleteUser(username, deleteAllRelatedData);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }
        }

        /// <summary>
        ///A test for EncodePassword
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost/FeelOfTravel")]
        [DeploymentItem("FeelOfTravel.dll")]
        public void EncodePasswordTest()
        {
            using (var docPreserver = new XDocumentPreserver(ProviderHelper.TEST_XML_PATH))
            {
                XmlMembershipProvider_Accessor target = new XmlMembershipProvider_Accessor(); // TODO: Initialize to an appropriate value
                string password = string.Empty; // TODO: Initialize to an appropriate value
                string expected = string.Empty; // TODO: Initialize to an appropriate value
                string actual;
                actual = target.EncodePassword(password);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }
        }

        /// <summary>
        ///A test for FindUsersByEmail
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost/FeelOfTravel")]
        public void FindUsersByEmailTest()
        {
            using (var docPreserver = new XDocumentPreserver(ProviderHelper.TEST_XML_PATH))
            {
                XmlMembershipProvider target = MakeXmlMembershipProvider(); // TODO: Initialize to an appropriate value
                string emailToMatch = string.Empty; // TODO: Initialize to an appropriate value
                int pageIndex = 0; // TODO: Initialize to an appropriate value
                int pageSize = 0; // TODO: Initialize to an appropriate value
                int totalRecords = 0; // TODO: Initialize to an appropriate value
                int totalRecordsExpected = 0; // TODO: Initialize to an appropriate value
                MembershipUserCollection expected = null; // TODO: Initialize to an appropriate value
                MembershipUserCollection actual;
                actual = target.FindUsersByEmail(emailToMatch, pageIndex, pageSize, out totalRecords);
                Assert.AreEqual(totalRecordsExpected, totalRecords);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }
        }

        /// <summary>
        ///A test for FindUsersByName
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost/FeelOfTravel")]
        public void FindUsersByNameTest()
        {
            using (var docPreserver = new XDocumentPreserver(ProviderHelper.TEST_XML_PATH))
            {
                XmlMembershipProvider target = MakeXmlMembershipProvider(); // TODO: Initialize to an appropriate value
                string usernameToMatch = string.Empty; // TODO: Initialize to an appropriate value
                int pageIndex = 0; // TODO: Initialize to an appropriate value
                int pageSize = 0; // TODO: Initialize to an appropriate value
                int totalRecords = 0; // TODO: Initialize to an appropriate value
                int totalRecordsExpected = 0; // TODO: Initialize to an appropriate value
                MembershipUserCollection expected = null; // TODO: Initialize to an appropriate value
                MembershipUserCollection actual;
                actual = target.FindUsersByName(usernameToMatch, pageIndex, pageSize, out totalRecords);
                Assert.AreEqual(totalRecordsExpected, totalRecords);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }
        }

        /// <summary>
        ///A test for GetAllUsers
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost/FeelOfTravel")]
        public void GetAllUsersTest()
        {
            using (var docPreserver = new XDocumentPreserver(ProviderHelper.TEST_XML_PATH))
            {
                XmlMembershipProvider target = MakeXmlMembershipProvider(); // TODO: Initialize to an appropriate value
                int pageIndex = 0; // TODO: Initialize to an appropriate value
                int pageSize = 0; // TODO: Initialize to an appropriate value
                int totalRecords = 0; // TODO: Initialize to an appropriate value
                int totalRecordsExpected = 0; // TODO: Initialize to an appropriate value
                MembershipUserCollection expected = null; // TODO: Initialize to an appropriate value
                MembershipUserCollection actual;
                actual = target.GetAllUsers(pageIndex, pageSize, out totalRecords);
                Assert.AreEqual(totalRecordsExpected, totalRecords);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }
        }

        /// <summary>
        ///A test for GetNumberOfUsersOnline
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost/FeelOfTravel")]
        public void GetNumberOfUsersOnlineTest()
        {
            using (var docPreserver = new XDocumentPreserver(ProviderHelper.TEST_XML_PATH))
            {
                XmlMembershipProvider target = MakeXmlMembershipProvider(); // TODO: Initialize to an appropriate value
                int expected = 0; // TODO: Initialize to an appropriate value
                int actual;
                actual = target.GetNumberOfUsersOnline();
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }
        }

        /// <summary>
        ///A test for GetPassword
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost/FeelOfTravel")]
        public void GetPasswordTest()
        {
            using (var docPreserver = new XDocumentPreserver(ProviderHelper.TEST_XML_PATH))
            {
                XmlMembershipProvider target = MakeXmlMembershipProvider(); // TODO: Initialize to an appropriate value
                string username = string.Empty; // TODO: Initialize to an appropriate value
                string answer = string.Empty; // TODO: Initialize to an appropriate value
                string expected = string.Empty; // TODO: Initialize to an appropriate value
                string actual;
                actual = target.GetPassword(username, answer);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }
        }

        /// <summary>
        ///A test for GetUser
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost/FeelOfTravel")]
        public void GetUserTest()
        {
            using (var docPreserver = new XDocumentPreserver(ProviderHelper.TEST_XML_PATH))
            {
                XmlMembershipProvider target = MakeXmlMembershipProvider(); // TODO: Initialize to an appropriate value
                string username = string.Empty; // TODO: Initialize to an appropriate value
                bool userIsOnline = false; // TODO: Initialize to an appropriate value
                MembershipUser expected = null; // TODO: Initialize to an appropriate value
                MembershipUser actual;
                actual = target.GetUser(username, userIsOnline);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }
        }

        /// <summary>
        ///A test for GetUser
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost/FeelOfTravel")]
        public void GetUserTest1()
        {
            using (var docPreserver = new XDocumentPreserver(ProviderHelper.TEST_XML_PATH))
            {
                XmlMembershipProvider target = MakeXmlMembershipProvider(); // TODO: Initialize to an appropriate value
                object providerUserKey = null; // TODO: Initialize to an appropriate value
                bool userIsOnline = false; // TODO: Initialize to an appropriate value
                MembershipUser expected = null; // TODO: Initialize to an appropriate value
                MembershipUser actual;
                actual = target.GetUser(providerUserKey, userIsOnline);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }
        }

        /// <summary>
        ///A test for GetUserFromElement
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost/FeelOfTravel")]
        [DeploymentItem("FeelOfTravel.dll")]
        public void GetUserFromElementTest()
        {
            using (var docPreserver = new XDocumentPreserver(ProviderHelper.TEST_XML_PATH))
            {
                XmlMembershipProvider_Accessor target = new XmlMembershipProvider_Accessor(); // TODO: Initialize to an appropriate value
                XElement userElement = null; // TODO: Initialize to an appropriate value
                MembershipUser expected = null; // TODO: Initialize to an appropriate value
                MembershipUser actual;
                actual = target.GetUserFromElement(userElement);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }
        }

        /// <summary>
        ///A test for GetUserNameByEmail
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost/FeelOfTravel")]
        public void GetUserNameByEmailTest()
        {
            using (var docPreserver = new XDocumentPreserver(ProviderHelper.TEST_XML_PATH))
            {
                XmlMembershipProvider target = MakeXmlMembershipProvider(); // TODO: Initialize to an appropriate value
                string email = string.Empty; // TODO: Initialize to an appropriate value
                string expected = string.Empty; // TODO: Initialize to an appropriate value
                string actual;
                actual = target.GetUserNameByEmail(email);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }
        }

        /// <summary>
        ///A test for Initialize
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost/FeelOfTravel")]
        public void InitializeTest()
        {
            using (var docPreserver = new XDocumentPreserver(ProviderHelper.TEST_XML_PATH))
            {
                XmlMembershipProvider target = MakeXmlMembershipProvider(); // TODO: Initialize to an appropriate value
                string name = string.Empty; // TODO: Initialize to an appropriate value
                NameValueCollection config = null; // TODO: Initialize to an appropriate value
                target.Initialize(name, config);
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }
        }

        /// <summary>
        ///A test for ResetPassword
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost/FeelOfTravel")]
        public void ResetPasswordTest()
        {
            using (var docPreserver = new XDocumentPreserver(ProviderHelper.TEST_XML_PATH))
            {
                XmlMembershipProvider target = MakeXmlMembershipProvider(); // TODO: Initialize to an appropriate value
                string username = string.Empty; // TODO: Initialize to an appropriate value
                string answer = string.Empty; // TODO: Initialize to an appropriate value
                string expected = string.Empty; // TODO: Initialize to an appropriate value
                string actual;
                actual = target.ResetPassword(username, answer);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }
        }

        /// <summary>
        ///A test for UnlockUser
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost/FeelOfTravel")]
        public void UnlockUserTest()
        {
            using (var docPreserver = new XDocumentPreserver(ProviderHelper.TEST_XML_PATH))
            {
                XmlMembershipProvider target = MakeXmlMembershipProvider(); // TODO: Initialize to an appropriate value
                string userName = string.Empty; // TODO: Initialize to an appropriate value
                bool expected = false; // TODO: Initialize to an appropriate value
                bool actual;
                actual = target.UnlockUser(userName);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }
        }

        /// <summary>
        ///A test for UpdateUser
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost/FeelOfTravel")]
        public void UpdateUserTest()
        {
            using (var docPreserver = new XDocumentPreserver(ProviderHelper.TEST_XML_PATH))
            {
                XmlMembershipProvider target = MakeXmlMembershipProvider(); // TODO: Initialize to an appropriate value
                MembershipUser user = null; // TODO: Initialize to an appropriate value
                target.UpdateUser(user);
                Assert.Inconclusive("A method that does not return a value cannot be verified.");
            }
        }

        /// <summary>
        ///A test for ValidateUser
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost/FeelOfTravel")]
        public void ValidateUserTest()
        {
            using (var docPreserver = new XDocumentPreserver(ProviderHelper.TEST_XML_PATH))
            {
                XmlMembershipProvider target = MakeXmlMembershipProvider(); // TODO: Initialize to an appropriate value
                string username = string.Empty; // TODO: Initialize to an appropriate value
                string password = string.Empty; // TODO: Initialize to an appropriate value
                bool expected = false; // TODO: Initialize to an appropriate value
                bool actual;
                actual = target.ValidateUser(username, password);
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }
        }

        /// <summary>
        ///A test for ApplicationName
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost/FeelOfTravel")]
        public void ApplicationNameTest()
        {
            using (var docPreserver = new XDocumentPreserver(ProviderHelper.TEST_XML_PATH))
            {
                XmlMembershipProvider target = MakeXmlMembershipProvider(); // TODO: Initialize to an appropriate value
                string expected = string.Empty; // TODO: Initialize to an appropriate value
                string actual;
                target.ApplicationName = expected;
                actual = target.ApplicationName;
                Assert.AreEqual(expected, actual);
                Assert.Inconclusive("Verify the correctness of this test method.");
            }
        }

        /// <summary>
        ///A test for EnablePasswordReset
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost/FeelOfTravel")]
        public void EnablePasswordResetTest()
        {
            using (var docPreserver = new XDocumentPreserver(ProviderHelper.TEST_XML_PATH))
            {
                XmlMembershipProvider target = MakeXmlMembershipProvider(); // TODO: Initialize to an appropriate value
                bool actual;
                actual = target.EnablePasswordReset;
                Assert.Inconclusive("Verify the correctness of this test method.");
            }
        }

        /// <summary>
        ///A test for EnablePasswordRetrieval
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost/FeelOfTravel")]
        public void EnablePasswordRetrievalTest()
        {
            using (var docPreserver = new XDocumentPreserver(ProviderHelper.TEST_XML_PATH))
            {
                XmlMembershipProvider target = MakeXmlMembershipProvider(); // TODO: Initialize to an appropriate value
                bool actual;
                actual = target.EnablePasswordRetrieval;
                Assert.Inconclusive("Verify the correctness of this test method.");
            }
        }

        /// <summary>
        ///A test for MaxInvalidPasswordAttempts
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost/FeelOfTravel")]
        public void MaxInvalidPasswordAttemptsTest()
        {
            using (var docPreserver = new XDocumentPreserver(ProviderHelper.TEST_XML_PATH))
            {
                XmlMembershipProvider target = MakeXmlMembershipProvider(); // TODO: Initialize to an appropriate value
                int actual;
                actual = target.MaxInvalidPasswordAttempts;
                Assert.Inconclusive("Verify the correctness of this test method.");
            }
        }

        /// <summary>
        ///A test for MinRequiredNonAlphanumericCharacters
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost/FeelOfTravel")]
        public void MinRequiredNonAlphanumericCharactersTest()
        {
            XmlMembershipProvider target = MakeXmlMembershipProvider(); // TODO: Initialize to an appropriate value
            int actual;
            actual = target.MinRequiredNonAlphanumericCharacters;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for MinRequiredPasswordLength
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost/FeelOfTravel")]
        public void MinRequiredPasswordLengthTest()
        {
            using (var docPreserver = new XDocumentPreserver(ProviderHelper.TEST_XML_PATH))
            {
                XmlMembershipProvider target = MakeXmlMembershipProvider(); // TODO: Initialize to an appropriate value
                int actual;
                actual = target.MinRequiredPasswordLength;
                Assert.Inconclusive("Verify the correctness of this test method.");
            }
        }

        /// <summary>
        ///A test for PasswordAttemptWindow
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost/FeelOfTravel")]
        public void PasswordAttemptWindowTest()
        {
            using (var docPreserver = new XDocumentPreserver(ProviderHelper.TEST_XML_PATH))
            {
                XmlMembershipProvider target = MakeXmlMembershipProvider(); // TODO: Initialize to an appropriate value
                int actual;
                actual = target.PasswordAttemptWindow;
                Assert.Inconclusive("Verify the correctness of this test method.");
            }
        }

        /// <summary>
        ///A test for PasswordFormat
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost/FeelOfTravel")]
        public void PasswordFormatTest()
        {
            using (var docPreserver = new XDocumentPreserver(ProviderHelper.TEST_XML_PATH))
            {
                XmlMembershipProvider target = MakeXmlMembershipProvider(); // TODO: Initialize to an appropriate value
                MembershipPasswordFormat actual;
                actual = target.PasswordFormat;
                Assert.Inconclusive("Verify the correctness of this test method.");
            }
        }

        /// <summary>
        ///A test for PasswordStrengthRegularExpression
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost/FeelOfTravel")]
        public void PasswordStrengthRegularExpressionTest()
        {
            using (var docPreserver = new XDocumentPreserver(ProviderHelper.TEST_XML_PATH))
            {
                XmlMembershipProvider target = MakeXmlMembershipProvider(); // TODO: Initialize to an appropriate value
                string actual;
                actual = target.PasswordStrengthRegularExpression;
                Assert.Inconclusive("Verify the correctness of this test method.");
            }
        }

        /// <summary>
        ///A test for RequiresQuestionAndAnswer
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost/FeelOfTravel")]
        public void RequiresQuestionAndAnswerTest()
        {
            using (var docPreserver = new XDocumentPreserver(ProviderHelper.TEST_XML_PATH))
            {
                XmlMembershipProvider target = MakeXmlMembershipProvider(); // TODO: Initialize to an appropriate value
                bool actual;
                actual = target.RequiresQuestionAndAnswer;
                Assert.Inconclusive("Verify the correctness of this test method.");
            }
        }

        /// <summary>
        ///A test for RequiresUniqueEmail
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [UrlToTest("http://localhost/FeelOfTravel")]
        public void RequiresUniqueEmailTest()
        {
            using (var docPreserver = new XDocumentPreserver(ProviderHelper.TEST_XML_PATH))
            {
                XmlMembershipProvider target = MakeXmlMembershipProvider(); // TODO: Initialize to an appropriate value
                bool actual;
                actual = target.RequiresUniqueEmail;
                Assert.Inconclusive("Verify the correctness of this test method.");
            }
        }
    }
}
