namespace FeelOfTravelTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FeelOfTravel.Model.Biz;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ArticleTests : TransactionScopeTest
    {
        [TestMethod]
        public void TestCreateAndReadArticle()
        {
            var article = new Article()
            {
                Header = "New article",
                Text = "Text",
                ArticleType = ArticleTypes.HotOffer
            };

            Assert.AreEqual(0, article.Id);
            article.Create();
            
            Assert.IsTrue(article.Id > 0);

            var sameArticle = new Article();
            sameArticle.Read(article.Id);

            Assert.AreEqual(article.Text, sameArticle.Text);
            Assert.AreEqual(article.Header, sameArticle.Header);
            Assert.AreEqual(article.Id, sameArticle.Id);
            Assert.AreEqual(article.ArticleType, sameArticle.ArticleType);
        }

        [TestMethod]
        public void TestUpdateArticle()
        {
            var article = new Article()
            {
                Header = "New article",
                Text = "Text",
                ArticleType = ArticleTypes.HotOffer
            };
            article.Create();

            article.Header = "header 2";
            article.Update();

            article.Read();
            Assert.AreEqual("header 2", article.Header);
        }

        [TestMethod]
        public void TestDeleteArticle()
        {
            var article = new Article()
            {
                Header = "New article",
                Text = "Text",
                ArticleType = ArticleTypes.HotOffer
            };
            article.Create();
            int id = article.Id;

            article.Delete();
            article.Read(id);
        }

        [TestMethod]
        public void TestGetArticlesList()
        {
            var article = new Article()
            {
                Header = "New article",
                Text = "Text",
                ArticleType = ArticleTypes.HotOffer
            };
            article.Create();

            var article2 = new Article()
            {
                Header = "New article2",
                Text = "Text2",
                ArticleType = ArticleTypes.Cruises
            };
            article2.Create();

            var twoArticles = Article.GetList();
            Assert.AreEqual(2, twoArticles.Count());
        }
    }
}
