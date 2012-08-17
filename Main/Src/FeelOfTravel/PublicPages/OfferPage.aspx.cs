using System;
using System.Collections.Generic;
using System.Linq;

using FeelOfTravel.Business.Domain;
using FeelOfTravel.Business.Repositories;
using FeelOfTravel.Business.Services;
using FeelOfTravel.Logic;
using FeelOfTravel.Logic.Common;

namespace FeelOfTravel.PublicPages
{
    public partial class OfferPage : System.Web.UI.Page
    {
        private IOfferService offerService;
        private ICategoryRepository categoryRepository;

        protected void Page_Load(object sender, EventArgs e)
        {
            offerService = CompositionRootHelper.GetCompositionRoot(Context).OfferService;
            categoryRepository = CompositionRootHelper.GetCompositionRoot(Context).CategoryRepository;

            if (!IsPostBack)
            {
                int offerId;
                if (int.TryParse(Request["offerId"], out offerId))
                {
                    var offer = offerService.Repository.Read(offerId);
                    BindControls(offer);
                }
            }
        }

        private void BindControls(Offer offer)
        {
            if (offer != null)
            {
                lblHeader.Text = offer.Header;
                lblPrice.Text = NumberFormatter.Format(offer.Price);
                lblText.Text = offer.TextBody;
                imgOffer.ImageUrl = offer.ImageUrl.FormatForHtml(Page.GetHost());

                offerInformation.Bind(offer);
            }
        }
    }
}