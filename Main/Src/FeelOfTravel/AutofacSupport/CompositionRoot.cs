using System;
using System.Collections.Generic;

using Autofac;

using FeelOfTravel.Business.Domain;
using FeelOfTravel.Business.Repositories;
using FeelOfTravel.Business.Services;

namespace FeelOfTravel.AutofacSupport
{
    public class CompositionRoot
    {
        private readonly IContainer container;

        private Dictionary<SimplePageType, ISimplePageRepository> simplePageMapping;

        public IArticleRepository ArticleRepository { get; set; }

        public ITeaserRepository TeaserRepository { get; set; }

        public IArticleService ArticleService { get; set; }

        public ITeaserService TeaserService { get; set; }

        public CompositionRoot(IContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }
            this.container = container;

            ArticleRepository = container.Resolve<IArticleRepository>();
            TeaserRepository = container.Resolve<ITeaserRepository>();
            ArticleService = container.Resolve<IArticleService>();
            TeaserService = container.Resolve<ITeaserService>();

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