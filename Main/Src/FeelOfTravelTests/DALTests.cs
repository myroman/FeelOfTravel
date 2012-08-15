// -----------------------------------------------------------------------
// <copyright file="DALTests.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace FeelOfTravelTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using FeelOfTravel.Model.Biz;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    [TestClass]
    public class DALTests
    {
        [TestMethod]
        public void TextCanContain8000Symbols()
        {
            MainPage mainPage = new MainPage();
            string bigString = this.Get8000SymbolString();

            mainPage.SaveContent(bigString);

            string newText = mainPage.GetPlainContent();
            Assert.AreEqual(bigString, newText);
        }

        public string Get8000SymbolString()
        {
            StringBuilder sb = new StringBuilder(8000);
            for (int i = 0; i < 8000; i++)
            {
                sb.Append('a');
            }

            return sb.ToString();
        }
    }
}
