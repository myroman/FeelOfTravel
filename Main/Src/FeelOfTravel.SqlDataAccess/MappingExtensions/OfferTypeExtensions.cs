using FeelOfTravel.Business.Domain;

namespace FeelOfTravel.SqlDataAccess.MappingExtensions
{
    public static class OfferTypeExtensions
    {
        public static OfferType ToDomainObject(this tbOfferType from)
        {
            return new OfferType
            {
                Id = from.id,
                Name = from.name
            };
        }
    }
}