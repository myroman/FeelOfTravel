using System;
using System.Linq;

using Autofac;

using FeelOfTravel.Business.Services;
using FeelOfTravel.SqlDataAccess.Repositories;

namespace FeelOfTravel.AutofacSupport
{
    public class CompositionRootBuilder
    {
        public static CompositionRoot Build()
        {
            // TODO: setup linq2sql connection issues.
            var builder = new ContainerBuilder();

            // TODO: register modules using attributes
            builder.RegisterModule<RepositoryRegistrationModule>();
            builder.RegisterModule<ServiceRegistrationModule>();
            
            return new CompositionRoot(builder.Build());
        }
    }
}