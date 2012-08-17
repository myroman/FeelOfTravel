using System;
using System.Linq;

using FeelOfTravel.Business.Domain;
using FeelOfTravel.Business.Repositories;

namespace FeelOfTravel.Business.Services
{
    public class OfferService : IOfferService
    {
        private readonly IOfferRepository offerRepository;
        private readonly IOfferTypeRepository offerTypeRepository;

        public OfferService(
            IOfferRepository offerRepository,
            IOfferTypeRepository offerTypeRepository)
        {
            if (offerRepository == null)
            {
                throw new ArgumentNullException("offerRepository");
            }
            if (offerTypeRepository == null)
            {
                throw new ArgumentNullException("offerTypeRepository");
            }
            this.offerRepository = offerRepository;
            this.offerTypeRepository = offerTypeRepository;
        }

        #region Implementation of IArticleService
        public IOfferRepository Repository
        {
            get { return offerRepository; }
        }

        public Offer[] GetOffers()
        {
            return offerRepository.GetList().ToArray();
        }

        public Offer[] GetOffers(OfferTypes offerType)
        {
            return offerRepository.GetList().Where(o => o.OfferType == offerType).ToArray();
        }

        public OfferType[] GetOfferTypes()
        {
            return offerTypeRepository.GetList().ToArray();
        }

        public OfferType GetOfferType(Offer offer)
        {
            if (offer == null)
            {
                throw new ArgumentNullException("offer");
            }
            if ((int)offer.OfferType > 0)
            {
                var offerType = offerTypeRepository.Read((int)offer.OfferType);
                return offerType;
            }
            return null;
        }

        public void DeleteArticle(Offer offerToDelete)
        {
            if (offerToDelete == null)
            {
                throw new ArgumentNullException("offerToDelete");
            }
            offerRepository.Remove(offerToDelete);
        }
        #endregion
    }
}