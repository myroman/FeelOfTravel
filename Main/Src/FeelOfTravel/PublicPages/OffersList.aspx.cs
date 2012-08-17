using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

using FeelOfTravel.Business.Domain;
using FeelOfTravel.Business.Repositories;
using FeelOfTravel.Business.Services;
using FeelOfTravel.Controls;
using FeelOfTravel.Logic;
using FeelOfTravel.Logic.Common;

namespace FeelOfTravel.PublicPages
{
    public partial class OffersList : Page
    {
        private IOfferService offerService;

        private IOfferTypeRepository offerTypeRepository;

        private OfferTypes OfferType { get; set; }

        private bool SaveOfferType(string offerType)
        {
            int value;
            if (!int.TryParse(offerType, out value))
            {
                return false;
            }

            OfferType = (OfferTypes)value;
            return true;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            offerService = CompositionRootHelper.GetCompositionRoot(Context).OfferService;
            offerTypeRepository = CompositionRootHelper.GetCompositionRoot(Context).OfferTypeRepository;
            if (!IsPostBack)
            {
                if (SaveOfferType(Request.Params["offerType"]))
                {
                    rptOffersList.DataSource = offerService.GetOffers(OfferType);
                }
                else
                {
                    rptOffersList.DataSource = offerService.GetOffers();
                }
            }
        }

        protected string GetHeaderText()
        {
            return Utils.MakePublicHeader(OfferTypeName);
        }

        protected string OfferTypeName
        {
            get
            {
                var offerType = offerTypeRepository.Read((int)OfferType);
                if (offerType != null)
                {
                    return offerType.Name;
                }
                return null;
            }
        }

        protected void OnOffersDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.DataItem is Offer)
            {
                var offer = e.Item.DataItem as Offer;

                var offerLink = (HyperLink)e.Item.FindControl("lnkArticleLink");
                var image = (Image)e.Item.FindControl("imgOffer");
                var lblHeader = (Label)e.Item.FindControl("lblHeader");
                var lblPrice = (Label)e.Item.FindControl("lblPrice");
                var offerInformation = (CommonArticleInformationControl)e.Item.FindControl("offerInformation");

                offerLink.NavigateUrl = GetLink(offer);
                image.Visible = IsImageVisible(offer);
                image.ImageUrl = offer.ImageUrl.FormatForHtml(Page.GetHost());
                lblHeader.Text = offer.Header;
                lblPrice.Text = NumberFormatter.Format(offer.Price);
                offerInformation.Bind(offer);
            }
        }

        private bool IsImageVisible(Offer offer)
        {
            return !string.IsNullOrEmpty(offer.ImageUrl);
        }

        private string GetLink(BusinessObjectBase offer)
        {
            const string Format = "~/PublicPages/OfferPage.aspx?offerId={0}";
            return string.Format(Format, offer.Id);
        }
    }
}