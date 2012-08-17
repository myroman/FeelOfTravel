using System;
using System.Collections.Generic;

using FeelOfTravel.Business.Domain;
using FeelOfTravel.Business.Repositories;

namespace FeelOfTravel.Business.Services.CategoryPresenter
{
    public class CategoryPresenter : ICategoryPresenter
    {
        private const string DefaultPageLink = "~/Default.aspx";
        private readonly ICategoryRepository categoryRepository;
        private readonly IOfferTypeRepository offerTypeRepository;

        public CategoryPresenter(ICategoryRepository categoryRepository, IOfferTypeRepository offerTypeRepository)
        {
            this.categoryRepository = categoryRepository;
            this.offerTypeRepository = offerTypeRepository;
        }

        public CategoryData[] GetCategories(CoreArticleData articleData)
        {
            var informationCategory = categoryRepository.Read((int)articleData.Category);

            var containedCategories = new List<CategoryData>
            {
                new CategoryData
                {
                    Name = informationCategory.Name,
                    Link = ResolveLinkForCategory(articleData.Category)
                }
            };

            if (articleData is Offer)
            {
                var offer = articleData as Offer;
                var offerTopic = offerTypeRepository.Read((int)offer.OfferType);

                containedCategories.Add(new CategoryData
                {
                    Name = offerTopic.Name,
                    Link = ResolveLinkForCategory(offer.OfferType)
                });
            }
            return containedCategories.ToArray();
        }

        private string ResolveLinkForCategory<TEnum>(TEnum categoryType)
        {
            var type = typeof(TEnum);
            if (!type.IsSubclassOf(typeof(Enum)))
            {
                throw new InvalidCastException("Cannot cast '" + type.FullName + "' to System.Enum.");
            }

            if (categoryType is InformationCategories)
            {
                switch ((InformationCategories)Enum.Parse(typeof(InformationCategories), categoryType.ToString()))
                {
                    case InformationCategories.Offers:
                        return "~/PublicPages/OffersList.aspx";
                    default:
                        return DefaultPageLink;
                }
            }
            if (categoryType is OfferTypes)
            {
                var offerCategory = (OfferTypes)Enum.Parse(typeof(OfferTypes), categoryType.ToString());
                const string Format = "~/PublicPages/OffersList.aspx?offerType={0}";
                
                return string.Format(Format, (int)offerCategory);
            }
            return string.Empty;
        }
    }
}