using System;
using System.Collections.Generic;

namespace FeelOfTravel.Business.Domain
{
    public class Teaser : BusinessObjectBase
    {
        public int RelatedArticleId { get; set; }

        public string Preamble { get; set; }

        public string ImageLink { get; set; }

        public Teaser()
        {
        }

        public Teaser(int relatedArticleId)
        {
            RelatedArticleId = relatedArticleId;
        }

        public string Validate()
        {
            if (string.IsNullOrEmpty(Preamble))
            {
                return "Заголовок тизера не должен быть пуст";
            }

            return string.Empty;
        }
    }
}