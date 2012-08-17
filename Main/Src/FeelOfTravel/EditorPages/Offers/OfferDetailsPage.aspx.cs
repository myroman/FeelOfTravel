using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.UI;

using AjaxControlToolkit;

using FeelOfTravel.Business.Domain;
using FeelOfTravel.Business.Services;
using FeelOfTravel.Logic;
using FeelOfTravel.Logic.Common;

namespace FeelOfTravel.EditorPages.Offers
{
    public partial class OfferDetailsPage : Page
    {
        public const string ImagePath = @"\UploadedImages\Offers\";
        private const string OfferIdKey = "offerId";
        private const string OfferImageKey = "OfferImageKey";
        private const string CurrentOfferIdKey = "currentOfferId";

        private IOfferService offerService;

        private int CurrentOfferId
        {
            get
            {
                return ViewState[CurrentOfferIdKey] != null
                    ? PageHelper.GetIdInSpecialWay(ViewState[CurrentOfferIdKey].ToString())
                    : 0;
            }

            set
            {
                ViewState[CurrentOfferIdKey] = value;
            }
        }

        private string RelativeImagePath
        {
            get { return Session[OfferImageKey] != null ? (string)Session[OfferImageKey] : null; }
            set
            {
                // Save into session, because during ajax upload contol event we can't use ViewState for storing data.
                Session[OfferImageKey] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            offerService = CompositionRootHelper.GetCompositionRoot(Context).OfferService;

            if (!IsPostBack)
            {
                afuImageUpload.OnClientUploadComplete = GetUploadCompleteCallbackName();

                ddlOfferType.DataSource = offerService.GetOfferTypes();
                ddlOfferType.DataValueField = "Id";
                ddlOfferType.DataTextField = "Name";

                ddlOfferType.DataBind();

                CurrentOfferId = PageHelper.GetIdInSpecialWay(Page.Request[OfferIdKey]);
                if (CurrentOfferId != 0)
                {
                    BindOfferControlsSafe(CurrentOfferId);
                }
            }
        }

        private Offer ReadOffer(int offerId)
        {
            return offerService.Repository.Read(offerId);
        }

        private void BindOfferControlsSafe(int offerId)
        {
            try
            {
                var offer = ReadOffer(offerId);
                var offerType = offerService.GetOfferType(offer);

                RelativeImagePath = offer.ImageUrl;

                ddlOfferType.SelectedValue = offerType.Id.ToString(CultureInfo.InvariantCulture);
                txtHeader.Text = offer.Header;
                txtText.Text = offer.TextBody;
                txtPrice.Text = offer.Price.ToString(CultureInfo.InvariantCulture);
                imgOfferImage.ImageUrl = RelativeImagePath.FormatForHtml(Page.GetHost());
            }
            catch (Exception ex)
            {
                lblOfferStatus.Text = ex.Message;
            }
        }

        protected void BtnSaveOfferClick(object sender, EventArgs e)
        {
            try
            {
                UpdateOfferUnsafe(CurrentOfferId);
            }
            catch (Exception ex)
            {
                lblOfferStatus.Text = "Cтатья не сохранена";
                throw;
            }
        }

        private void UpdateOfferUnsafe(int offerId)
        {
            var offer = FillOfferOrCreate(offerId);
            offerService.Repository.Update(offer);
            CurrentOfferId = offer.Id;

            lblOfferStatus.Text = offerId == 0 ? "Акция создана" : "Акция сохранена";
        }

        private Offer FillOfferOrCreate(int id)
        {
            int offerTypeId;
            if (!int.TryParse(ddlOfferType.SelectedValue, out offerTypeId))
            {
                throw new PageException("Неправильный id типа акции");
            }

            double price;
            if (!double.TryParse(txtPrice.Text, out price))
            {
                throw new PageException("Введите число для цены");
            }
            if (id == 0)
            {
                var currentOffer = new Offer
                {
                    Id = id,
                    OfferType = (OfferTypes)offerTypeId,
                    Header = txtHeader.Text,
                    TextBody = txtText.Text,
                    Price = price,
                    ImageUrl = RelativeImagePath
                };
                return currentOffer;
            }
            return ReadOffer(id);
        }

        protected string GetUploadCompleteCallbackName()
        {
            return "uploadCompleteFunc_" + ClientID;
        }

        protected void AfuImageUpload_OnUploadedComplete(object sender, AsyncFileUploadEventArgs ea)
        {
            if (ea.State == AsyncFileUploadState.Success)
            {
                var filename = System.IO.Path.GetFileName(afuImageUpload.FileName);

                // TODO: replace with constant
                var mappedPath = Server.MapPath("~/UploadedImages/Offers/") + filename;
                afuImageUpload.SaveAs(mappedPath);

                RelativeImagePath = ImagePath + filename;
            }
        }
    }
}