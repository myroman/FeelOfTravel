using System;
using System.Linq;

using FeelOfTravel.Business.Services;
using FeelOfTravel.Logic;

namespace FeelOfTravel.EditorPages.Teasers
{
    public partial class TeaserManagementPage : System.Web.UI.Page, IEditorEntitiesManager
    {
        private ITeaserService teaserService;

        private TeasersProvider teasersProvider;

        private TeasersProvider TeasersProvider
        {
            get { return teasersProvider ?? (teasersProvider = new TeasersProvider(teaserService)); }
        }
        
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            teaserService = CompositionRootHelper.GetCompositionRoot(Context).TeaserService;
            emcTeasers.Initialize(TeasersProvider, this);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                emcTeasers.DataSource = TeasersProvider.Teasers;

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
            Page.Response.Redirect("~/EditorPages/Teasers/TeaserDetailsPage.aspx");
        }

        public void Delete(int id)
        {
            var teaserToChange = TeasersProvider.Teasers.SingleOrDefault(t => t.Id == id);
            if (teaserToChange == null)
            {
                throw new ArgumentException("Wrong id", "id");
            }

            teaserService.Repository.Remove(teaserToChange);
        }

        public bool AddingIsEnabled
        {
            get { return false; }
        }
    }
}