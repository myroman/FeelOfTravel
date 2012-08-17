using System;
using System.Collections.Generic;

using Autofac;

using FeelOfTravel.Business.Domain;
using FeelOfTravel.Business.Repositories;
using FeelOfTravel.Business.Services;
using FeelOfTravel.Business.Services.CategoryPresenter;

namespace FeelOfTravel.AutofacSupport
{
    public class CompositionRoot
    {
        private readonly IContainer container;

        private Dictionary<SimplePageType, ISimplePageRepository> simplePageMapping;

        public IOfferRepository OfferRepository { get; set; }

        public IOfferTypeRepository OfferTypeRepository { get; set; }

        public IOfferService OfferService { get; set; }

        public ICategoryRepository CategoryRepository { get; set; }

        public ICategoryPresenter CategoryPresenter { get; set; }

        public CompositionRoot(IContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }
            this.container = container;

            OfferRepository = container.Resolve<IOfferRepository>();
            OfferTypeRepository = container.Resolve<IOfferTypeRepository>();
            OfferService = container.Resolve<IOfferService>();
            CategoryRepository = container.Resolve<ICategoryRepository>();
            CategoryPresenter = container.Resolve<ICategoryPresenter>();

            simplePageMapping = new Dictionary<SimplePageType, ISimplePageRepository>();
        }
        
        public ISimplePageRepository GetSimplePageRepository(SimplePageType pageType)
        {
            if (simplePageMapping.ContainsKey(pageType))
            {
                return simplePageMapping[pageType];
            }
            simplePageMapping[pageType] = container.Resolve<ISimplePageRepository>(new NamedParameter("pageType", pageType));
            return simplePageMapping[pageType];
        }
    }
}