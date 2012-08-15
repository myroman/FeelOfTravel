using System;
using System.Collections.Generic;
using System.Linq;

using FeelOfTravel.Business.Domain;
using FeelOfTravel.Business.Services;
using FeelOfTravel.Logic;

namespace FeelOfTravel.PublicPages
{
    public partial class Cruises : System.Web.UI.Page
    {
        private ITeaserService teaserService;

        protected void Page_Load(object sender, EventArgs e)
        {
            teaserService = CompositionRootHelper.GetCompositionRoot(Context).TeaserService;
            if (!IsPostBack)
            {
                tsvCruises.DataSource = teaserService.GetTeasers(ArticleTypes.Cruises);
            }
        }
    }
}