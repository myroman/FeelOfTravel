using System;

using Autofac;

namespace FeelOfTravel.Business.Services
{
    public class ServiceRegistrationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ArticleService>()
                .As<IArticleService>()
                .SingleInstance();
            builder.RegisterType<TeaserService>()
                .As<ITeaserService>()
                .SingleInstance();
        }
    }
}