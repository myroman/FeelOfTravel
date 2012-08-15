namespace FeelOfTravelTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using FeelOfTravel.Model.Biz;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PagesTests
    {
        [TestMethod]
        public void CheckMainPage()
        {
            var page = new MainPage();
            const string TEST_TEXT = "Text which rewrote";

            page.SaveContent("Some text..");
            page.SaveContent(TEST_TEXT);

            var sameAboutPage = new MainPage();
            string actual = sameAboutPage.GetPlainContent();
            Assert.AreEqual(TEST_TEXT, actual);
        }

        [TestMethod]
        public void CheckAboutPage()
        {
            var aboutPage = new AboutPage();
            const string TEST_TEXT = "Text which rewrote";

            aboutPage.SaveContent("Some text..");
            aboutPage.SaveContent(TEST_TEXT);

            var sameAboutPage = new AboutPage();
            string actual = sameAboutPage.GetPlainContent();
            Assert.AreEqual(TEST_TEXT, actual);
        }

        [TestMethod]
        public void CheckContactsPage()
        {
            var page = new ContactsPage();
            const string TEST_TEXT = "Text which rewrote";

            page.SaveContent("Some text..");
            page.SaveContent(TEST_TEXT);

            var sameAboutPage = new ContactsPage();
            string actual = sameAboutPage.GetPlainContent();
            Assert.AreEqual(TEST_TEXT, actual);
        }
    }
}
