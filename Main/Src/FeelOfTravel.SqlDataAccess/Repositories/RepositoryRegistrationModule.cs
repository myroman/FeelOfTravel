﻿using System;
using System.Configuration;

using Autofac;

using FeelOfTravel.Business.Domain;
using FeelOfTravel.Business.Repositories;

namespace FeelOfTravel.SqlDataAccess.Repositories
{
    public class RepositoryRegistrationModule : Module
    {
        private const string ConnectionStringParam = "connectionString";

        protected override void Load(ContainerBuilder builder)
        {
            // TODO: setup linq2sql connection issues.
            var connectionString = ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString;
            
            builder.RegisterType<SqlOfferRepository>()
                .As<IOfferRepository>()
                .WithParameter(ConnectionStringParam, connectionString)
                .SingleInstance();
            builder.RegisterType<SqlOfferTypeRepository>()
                .As<IOfferTypeRepository>()
                .WithParameter(ConnectionStringParam, connectionString)
                .SingleInstance();
            builder.RegisterType<SqlCategoryRepository>()
                .As<ICategoryRepository>()
                .WithParameter(ConnectionStringParam, connectionString)
                .SingleInstance();

            builder.Register<ISimplePageRepository>(
                (c, p) =>
                {
                    var pageType = p.Named<SimplePageType>("pageType");
                    switch (pageType)
                    {
                        case SimplePageType.Main:
                            return new MainPageRepository(connectionString);
                        case SimplePageType.Contacts:
                            return new ContactsPageRepository(connectionString);
                        case SimplePageType.About:
                            return new AboutPageRepository(connectionString);
                        default:
                            return null;
                    }
                }).InstancePerDependency();
        }
    }
}