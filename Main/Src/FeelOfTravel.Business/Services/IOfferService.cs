using FeelOfTravel.Business.Domain;
using FeelOfTravel.Business.Repositories;

namespace FeelOfTravel.Business.Services
{
    public interface IOfferService
    {
        IOfferRepository Repository { get; }

        Offer[] GetOffers();

        Offer[] GetOffers(OfferTypes offerType);

        OfferType[] GetOfferTypes();
        
        OfferType GetOfferType(Offer offer);
        
        void DeleteArticle(Offer offerToDelete);
    }
}