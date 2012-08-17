using System;

using Autofac;

using FeelOfTravel.Business.Services.CategoryPresenter;

namespace FeelOfTravel.Business.Services
{
    public class ServiceRegistrationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<OfferService>()
                .As<IOfferService>()
                .SingleInstance();
            builder.RegisterType<CategoryPresenter.CategoryPresenter>()
                .As<ICategoryPresenter>()
                .SingleInstance();
        }
    }
}