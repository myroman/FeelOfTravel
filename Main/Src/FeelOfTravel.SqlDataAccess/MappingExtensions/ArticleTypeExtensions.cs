using FeelOfTravel.Business.Domain;

namespace FeelOfTravel.SqlDataAccess.MappingExtensions
{
    public static class ArticleTypeExtensions
    {
        public static ArticleType ToDomainObject(this tbArticleType from)
        {
            return new ArticleType
            {
                Id = from.articleTypeId,
                Description = from.articleType
            };
        }
    }
}