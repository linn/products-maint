﻿namespace Linn.Products.IoC
{
    using System.Collections.Generic;

    using Autofac;

    using Linn.Common.Facade;
    using Linn.Common.Reporting.Models;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Facade.ResourceBuilders;

    public class ResponsesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // resource builders
            builder.RegisterType<ResultsModelResourceBuilder>().As<IResourceBuilder<ResultsModel>>();
            builder.RegisterType<CartonTypeResourceBuilder>().As<IResourceBuilder<CartonType>>();
            builder.RegisterType<SernosConfigResourceBuilder>().As<IResourceBuilder<SernosConfig>>();
            builder.RegisterType<SernosConfigsResourceBuilder>().As<IResourceBuilder<IEnumerable<SernosConfig>>>();
        }
    }
}
