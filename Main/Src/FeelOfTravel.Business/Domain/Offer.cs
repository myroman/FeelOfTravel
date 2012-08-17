using System;
using System.Collections.Generic;
using System.Linq;

namespace FeelOfTravel.Business.Domain
{
    public class Offer : CoreArticleData
    {
        public Offer()
        {
            Category = InformationCategories.Offers;
        }

        public OfferTypes OfferType { get; set; }

        public double Price { get; set; }

        public static void Copy(Offer from, Offer to)
        {
            if (from == null)
            {
                throw new ArgumentNullException("from");
            }
            if (to == null)
            {
                throw new ArgumentNullException("to");
            }

            to.OfferType = from.OfferType;
            to.Header = from.Header;
            to.TextBody = from.TextBody;
            to.Price = from.Price;
        }

        public override string Validate()
        {
            var offerType = (int)OfferType;
            if ((offerType != 1) && (offerType != 2) && (offerType != 3))
            {
                return "Validation failed because of wrong offer type id";
            }
            return string.Empty;
        }
    }
}
