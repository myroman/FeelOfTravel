using FeelOfTravel.Business.Domain;

namespace FeelOfTravel.SqlDataAccess.MappingExtensions
{
    public static class ArticleExtensions
    {
         public static Article ToDomainObject(this tbArticle articleInDb)
         {
             return new Article
             {
                 Id = articleInDb.articleId,
                 Header = articleInDb.header,
                 TextBody = articleInDb.text,
                 ArticleType = (ArticleTypes)articleInDb.articleTypeId,
                 Price = articleInDb.price.HasValue ? articleInDb.price.Value : 0
             };
         }

         public static void FillDbObject(this Article from, tbArticle to)
         {
             to.articleId = from.Id;
             to.articleTypeId = (int)from.ArticleType;
             to.header = from.Header;
             to.text = from.TextBody;
             to.price = from.Price;
         }
    }
}