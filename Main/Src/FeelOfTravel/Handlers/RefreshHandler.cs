using System;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;

using FeelOfTravel.Business.Services;
using FeelOfTravel.Controls;
using FeelOfTravel.EditorPages.Articles;
using FeelOfTravel.EditorPages.Teasers;
using FeelOfTravel.Logic;

namespace FeelOfTravel.Handlers
{
    public class RefreshHandler : IHttpHandler
    {
        private ITeaserService teaserService;
        private IArticleService articleService;

        #region IHttpHandler Members

        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                InjectServices(context);

                if (!string.IsNullOrEmpty(context.Request.Params["type"]))
                {
                    var response = GetResponse(context.Request.Params["type"]);

                    context.Response.StatusCode = 200;
                    context.Response.Clear();
                    context.Response.ContentType = "html";
                    if (string.IsNullOrEmpty(response))
                    {
                        response = "\n";
                    }

                    context.Response.Write(response);
                }
            }
            catch (Exception exc)
            {
                context.Response.StatusCode = 400;
                context.Response.Write(exc.Message);
            }

        }

        private void InjectServices(HttpContext context)
        {
            var root = CompositionRootHelper.GetCompositionRoot(context);
            teaserService = root.TeaserService;
            articleService = root.ArticleService;
        }
        #endregion
        private string GetResponse(string type)
        {
            if (type == "article")
            {
                return GetArticlesList();
            }
            
            if (type == "teaser")
            {
                return GetTeasersList();
            }

            throw new ArgumentException("Wrong king of entities", "type");
        }

        private string GetTeasersList()
        {
            var pageHolder = new TeaserManagementPage();
            var response = new StringBuilder();
            using (var stringWriter = new StringWriter(response))
            {
                using (var htmlWriter = new HtmlTextWriter(stringWriter))
                {
                    var entitiesControl = (EntitiesListControl)pageHolder.LoadControl("~/Controls/EntitiesListControl.ascx");
                    var provider = new TeasersProvider(teaserService);

                    entitiesControl.Provider = provider;
                    entitiesControl.DataSource = provider.Teasers;
                    entitiesControl.DataBind();

                    entitiesControl.RenderControl(htmlWriter);
                }
            }

            return response.ToString();
        }

        private string GetArticlesList()
        {
            var pageHolder = new ArticleManagementPage();
            var response = new StringBuilder();
            using (var stringWriter = new StringWriter(response))
            {
                using (var htmlWriter = new HtmlTextWriter(stringWriter))
                {
                    var entitiesControl = (EntitiesListControl)pageHolder.LoadControl("~/Controls/EntitiesListControl.ascx");
                    var provider = new ArticlesProvider(articleService);

                    entitiesControl.Provider = provider;
                    entitiesControl.DataSource = provider.Articles;
                    entitiesControl.DataBind();

                    entitiesControl.RenderControl(htmlWriter);
                }
            }

            return response.ToString();
        }
    }
}
