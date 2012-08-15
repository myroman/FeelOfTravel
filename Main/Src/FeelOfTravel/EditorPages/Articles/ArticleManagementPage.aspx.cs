using System;
using System.Linq;

using FeelOfTravel.Business.Services;
using FeelOfTravel.Logic;

namespace FeelOfTravel.EditorPages.Articles
{
    public partial class ArticleManagementPage : System.Web.UI.Page, IEditorEntitiesManager
    {
        private IArticleService articleService;

        private ArticlesProvider articlesProvider;

        private ArticlesProvider ArticlesProvider
        {
            get { return articlesProvider ?? (articlesProvider = new ArticlesProvider(articleService)); }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            articleService = CompositionRootHelper.GetCompositionRoot(Context).ArticleService;
            emcArticles.Initialize(ArticlesProvider, this);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                emcArticles.DataSource = ArticlesProvider.Articles;
                
                if (!string.IsNullOrEmpty(Request.Params["idToDelete"]))
                {
                    int id;
                    if (!int.TryParse(Request.Params["idToDelete"], out id))
                    {
                        return;
                    }

                    try
                    {
                        Delete(id);

                        Response.StatusCode = 200;
                        Response.Clear();
                    }
                    catch (Exception exc)
                    {
                        Response.StatusCode = 400;
                        Response.ContentType = "text";

                        Response.Write(exc.Message);
                    }
                    finally
                    {
                        Response.End();
                    }
                }
            }
        }

        public void Add()
        {
            Page.Response.Redirect("~/EditorPages/Articles/ArticleDetailsPage.aspx");
        }

        public void Delete(int id)
        {
            var articleToChange = ArticlesProvider.Articles.SingleOrDefault(art => art.Id == id);
            if (articleToChange == null)
            {
                throw new ArgumentException("Wrong id", "id");
            }

            articleService.DeleteArticle(articleToChange, true);
        }

        public bool AddingIsEnabled
        {
            get { return true; }
        }
    }
}