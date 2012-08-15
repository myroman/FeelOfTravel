using System;
using System.Collections.Generic;
using System.Linq;

namespace FeelOfTravel.Business.Domain
{
    public class Article : BusinessObjectBase
    {
        public ArticleTypes ArticleType { get; set; }

        public string Header { get; set; }

        public string TextBody { get; set; }

        public double Price { get; set; }

        public string Validate()
        {
            var articleTypeId = (int)ArticleType;
            if ((articleTypeId != 1) && (articleTypeId != 2) && (articleTypeId != 3))
            {
                return "Validation failed because of wrong article type id";
            }
            return string.Empty;
        }

        public static void Copy(Article from, Article to)
        {
            if (from == null)
            {
                throw new ArgumentNullException("from");
            }
            if (to == null)
            {
                throw new ArgumentNullException("to");
            }

            to.ArticleType = from.ArticleType;
            to.Header = from.Header;
            to.TextBody = from.TextBody;
            to.Price = from.Price;
        }
    }
}
