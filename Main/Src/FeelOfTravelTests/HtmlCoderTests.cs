using System;
using FeelOfTravel.Business.Utils;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FeelOfTravelTests
{
    [TestClass()]
    public class HtmlCoderTests
    {
        [TestMethod()]
        public void TestBScreens()
        {
            string s = "<b>Text</b>";
            string expected = s; // TODO: Initialize to an appropriate value
            string actual = HtmlCoder.Encode(s);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void TestImgScreens()
        {
            string input = "<img src=\"1.jpg\" />";
            Assert.AreEqual(input, HtmlCoder.Encode(input));
        }
    }
}
