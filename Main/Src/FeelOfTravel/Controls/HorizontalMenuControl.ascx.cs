using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;

using FeelOfTravel.Business.Domain;

namespace FeelOfTravel.Controls
{
    public partial class HorizontalMenuControl : UserControl
    {
        private const string OfferFormat = "{0}?offerType={1}";

        protected void Page_Load(object sender, EventArgs e)
        {
            DataBind();
        }

        protected bool CurrentUserIsEditor
        {
            get
            {
                var belongs = Context.User.IsInRole("Editors");
                return belongs;
            }
        }

        protected string DefaultPageUrl
        {
            get { return ResolveClientUrl("~/Default.aspx"); }
        }

        protected string GetOffersUrl(OfferTypes offerType)
        {
            return string.Format(OfferFormat, ResolveClientUrl("~/PublicPages/OffersList.aspx"), (int)offerType);
        }

    }
}