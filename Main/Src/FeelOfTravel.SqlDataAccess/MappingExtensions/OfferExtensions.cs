using FeelOfTravel.Business.Domain;

namespace FeelOfTravel.SqlDataAccess.MappingExtensions
{
    public static class OfferExtensions
    {
         public static Offer ToDomainObject(this tbOffer offer)
         {
             return new Offer
             {
                 Id = offer.id,
                 Category = (InformationCategories)offer.tbCoreArticleData.categoryId,
                 Header = offer.tbCoreArticleData.header,
                 TextBody = offer.tbCoreArticleData.text,
                 PublishDate = offer.tbCoreArticleData.publishDate,
                 ImageUrl = offer.tbCoreArticleData.imageUrl,
                 OfferType = (OfferTypes)offer.typeId,
                 Price = offer.price.HasValue ? offer.price.Value : 0
             };
         }

         public static void FillDbObject(this Offer from, tbOffer to)
         {
             to.id = from.Id;
             if (to.tbCoreArticleData == null)
             {
                 to.tbCoreArticleData = new tbCoreArticleData();
             }
             to.tbCoreArticleData.categoryId = (int)from.Category;
             to.tbCoreArticleData.header = from.Header;
             to.tbCoreArticleData.text = from.TextBody;
             to.tbCoreArticleData.imageUrl = from.ImageUrl;
             to.tbCoreArticleData.publishDate = from.PublishDate;
             to.typeId = (int)from.OfferType;
             to.price = from.Price;
         }
    }
}