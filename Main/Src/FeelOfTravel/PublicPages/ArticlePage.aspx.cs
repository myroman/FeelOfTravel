using System;
using System.Collections.Generic;
using System.Linq;

using FeelOfTravel.Business.Domain;
using FeelOfTravel.Business.Services;
using FeelOfTravel.Logic;

namespace FeelOfTravel.PublicPages
{
    public partial class ArticlePage : System.Web.UI.Page
    {
        private const string ARTICLE_ID_KEY = "articleId";

        private IArticleService articleService;

        private Article article;

        protected void Page_Load(object sender, EventArgs e)
        {
            articleService = CompositionRootHelper.GetCompositionRoot(Context).ArticleService;

            if (!IsPostBack)
            {
                if (Page.Request["articleId"] != null)
                {
                    ArticleId = int.Parse(Page.Request["articleId"]);

                    lblHeader.Text = Article.Header;
                    lblText.Text = Article.TextBody;
                }
            }
        }

        private int ArticleId
        {
            get
            {
                try
                {
                    return (int)ViewState[ARTICLE_ID_KEY];
                }
                catch (InvalidCastException)
                {
                    return 0;
                }
                catch (NullReferenceException)
                {
                    return 0;
                }
            }

            set { ViewState[ARTICLE_ID_KEY] = value; }
        }

        private Article Article
        {
            get { return article ?? (article = articleService.Repository.Read(ArticleId)); }
        }
    }
}