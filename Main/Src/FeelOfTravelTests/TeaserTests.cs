using System.Linq;

using FeelOfTravel.Business.Domain;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FeelOfTravelTests
{
    [TestClass]
    public class TeaserTests : TransactionScopeTest
    {
        [TestMethod]
        public void TestCreateAndReadTeaser()
        {
            var article = this.MakeSampleArticle();
            var teaser = new Teaser(article)
            {
                Preamble = "New teaser",
                ImageLink = "Text"
            };

            Assert.AreEqual(0, teaser.Id);
            teaser.Create();

            Assert.IsTrue(teaser.Id > 0);

            var sameTeaser = new Teaser(article);
            sameTeaser.Read(teaser.Id);

            Assert.AreEqual(teaser.ImageLink, sameTeaser.ImageLink);
            Assert.AreEqual(teaser.Preamble, sameTeaser.Preamble);
            Assert.AreEqual(teaser.Id, sameTeaser.Id);
        }

        private Article MakeSampleArticle()
        {
            var article = new Article { ArticleType = ArticleTypes.HotOffer, Header = "Sample article", Text = "Police!" };
            article.Create();

            return article;
        }

        [TestMethod]
        public void TestUpdateTeaser()
        {
            var article = this.MakeSampleArticle();
            var teaser = new Teaser(article)
            {
                Preamble = "New teaser",
                ImageLink = "Text"
            };
            teaser.Create();

            teaser.Preamble = "header 2";
            teaser.Update();

            teaser.Read();
            Assert.AreEqual("header 2", teaser.Preamble);
        }

        [TestMethod]
        public void TestDeleteTeaser()
        {
            var article = this.MakeSampleArticle();
            var teaser = new Teaser(article)
            {
                Preamble = "New teaser",
                ImageLink = "Text"
            };
            teaser.Create();
            int id = teaser.Id;

            teaser.Delete();
            teaser.Read(id);
        }

        [TestMethod]
        public void TestGetTeasersList()
        {
            var article = this.MakeSampleArticle();
            var teaser = new Teaser(article)
            {
                Preamble = "New teaser",
                ImageLink = "Text"
            };
            teaser.Create();

            var teaser2 = new Teaser(article)
            {
                Preamble = "New teaser2",
                ImageLink = "Text2"
            };
            teaser2.Create();

            var twoTeasers = Teaser.GetList();
            Assert.AreEqual(2, twoTeasers.Count());
        }
    }
}