using System;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;

using FeelOfTravel.Business.Services;
using FeelOfTravel.Controls;
using FeelOfTravel.EditorPages.Offers;
using FeelOfTravel.Logic;

namespace FeelOfTravel.Handlers
{
    public class RefreshHandler : IHttpHandler
    {
        private IOfferService offerService;

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
            offerService = root.OfferService;
        }
        #endregion
        private string GetResponse(string type)
        {
            if (type == "offer")
            {
                return GetArticlesList();
            }
            
            throw new ArgumentException("Wrong king of entities", "type");
        }

        private string GetArticlesList()
        {
            var pageHolder = new OfferManagementPage();
            var response = new StringBuilder();
            using (var stringWriter = new StringWriter(response))
            {
                using (var htmlWriter = new HtmlTextWriter(stringWriter))
                {
                    var entitiesControl = (EntitiesListControl)pageHolder.LoadControl("~/Controls/EntitiesListControl.ascx");
                    var provider = new OffersProvider(offerService);

                    entitiesControl.Provider = provider;
                    entitiesControl.DataSource = provider.Offers;
                    entitiesControl.DataBind();

                    entitiesControl.RenderControl(htmlWriter);
                }
            }

            return response.ToString();
        }
    }
}
