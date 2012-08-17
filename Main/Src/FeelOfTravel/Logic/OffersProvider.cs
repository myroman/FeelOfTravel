using System;
using System.Collections.Generic;
using System.Linq;

using FeelOfTravel.Business.Domain;
using FeelOfTravel.Business.Services;
using FeelOfTravel.Logic.Common;
using FeelOfTravel.Model.Utils;

namespace FeelOfTravel.Logic
{
    public class OffersProvider : IEditorEntitiesProvider
    {
        private IOfferService offerService;

        public OffersProvider(IOfferService offerService)
        {
            if (offerService == null)
            {
                throw new ArgumentNullException("offerService");
            }
            this.offerService = offerService;
        }

        public string GetItemText(object dataItem)
        {
            var offer = dataItem as Offer;
            if (offer == null) return null;

            return offer.Header;
        }

        private Offer[] offers;

        public Offer[] Offers
        {
            get { return offers ?? (offers = offerService.GetOffers()); }
        }

        public EntitiesTransferObject EntitiesTransferObject
        {
            get
            {
                var transferObj = new EntitiesTransferObject
                {
                    EntityDetailsUrl = "OfferDetailsPage.aspx",
                    EntityUrlParam = "offerId",
                    EntityDeleteUrl = "OfferManagementPage.aspx",
                    JsonEntitiesList = GetJsonEntitiesList(),
                    MessageForDelete = MessageForDelete,
                    RefreshType = "offer"
                };

                return transferObj;
            }
        }

        private string GetJsonEntitiesList()
        {
            string jsonArticles = Offers.Select(art => new
            {
                art.Id,
                Description = art.TextBody
                    .SafeCrop(40)
                    .Replace('\n', ' ')
            }).ToArray().ToJSON();

            return jsonArticles;
        }

        private string MessageForDelete
        {
            get { return "Вы уверены, что хотите удалить статью?"; }
        }
    }
}