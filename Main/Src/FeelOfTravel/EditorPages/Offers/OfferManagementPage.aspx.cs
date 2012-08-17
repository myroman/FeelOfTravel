using System;
using System.Linq;

using FeelOfTravel.Business.Services;
using FeelOfTravel.Logic;

namespace FeelOfTravel.EditorPages.Offers
{
    public partial class OfferManagementPage : System.Web.UI.Page, IEditorEntitiesManager
    {
        private IOfferService offerService;

        private OffersProvider offersProvider;

        private OffersProvider OffersProvider
        {
            get { return offersProvider ?? (offersProvider = new OffersProvider(offerService)); }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            offerService = CompositionRootHelper.GetCompositionRoot(Context).OfferService;
            emcArticles.Initialize(OffersProvider, this);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                emcArticles.DataSource = OffersProvider.Offers;
                
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
            Page.Response.Redirect("~/EditorPages/Offers/OfferDetailsPage.aspx");
        }

        public void Delete(int id)
        {
            var offerToDelete = OffersProvider.Offers.SingleOrDefault(art => art.Id == id);
            if (offerToDelete == null)
            {
                throw new ArgumentException("Wrong id", "id");
            }

            offerService.DeleteArticle(offerToDelete);
        }

        public bool AddingIsEnabled
        {
            get { return true; }
        }
    }
}