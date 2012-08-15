using FeelOfTravel.Business.Domain;

namespace FeelOfTravel.SqlDataAccess.MappingExtensions
{
    public static class TeaserExtensions
    {
        public static Teaser ToDomainObject(this tbTeaser teaserInDb)
        {
            var teaser = new Teaser(teaserInDb.relatedArticleId)
            {
                Id = teaserInDb.teaserId,
                ImageLink = teaserInDb.imageLink,
                Preamble = teaserInDb.preamble,
                RelatedArticleId = teaserInDb.relatedArticleId
            };

            return teaser;
        }

        public static void FillDbObject(this Teaser from, tbTeaser to)
        {
            to.teaserId = from.Id;
            to.preamble = from.Preamble;
            to.imageLink = from.ImageLink;
            to.relatedArticleId = from.RelatedArticleId;
        }
    }
}