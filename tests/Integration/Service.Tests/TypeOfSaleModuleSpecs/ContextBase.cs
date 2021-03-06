﻿namespace Linn.Products.Service.Tests.TypeOfSaleModuleSpecs
{
    using System.Collections.Generic;
    using System.Security.Claims;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Facade.ResourceBuilders;
    using Linn.Products.Resources;
    using Linn.Products.Service.Modules;
    using Linn.Products.Service.ResponseProcessors;

    using Nancy.Testing;

    using NSubstitute;

    using NUnit.Framework;

    public abstract class ContextBase : NancyContextBase
    {
        protected IFacadeService<TypeOfSale, string, TypeOfSaleResource, TypeOfSaleResource> TypeOfSaleService { get; set; }

        [SetUp]
        public void EstablishContext()
        {
            this.TypeOfSaleService = Substitute.For<IFacadeService<TypeOfSale, string, TypeOfSaleResource, TypeOfSaleResource>>();

            var bootstrapper = new ConfigurableBootstrapper(
                with =>
                    {
                        with.Dependency(this.TypeOfSaleService);
                        with.Dependency<IResourceBuilder<TypeOfSale>>(new TypeOfSaleResourceBuilder());
                        with.Dependency<IResourceBuilder<IEnumerable<TypeOfSale>>>(new TypesOfSaleResourceBuilder());
                        with.Module<TypeOfSaleModule>();
                        with.ResponseProcessor<TypeOfSaleResponseProcessor>();
                        with.ResponseProcessor<TypesOfSaleResponseProcessor>();
                        with.RequestStartup(
                            (container, pipelines, context) =>
                            {
                                var claims = new List<Claim>
                                                    {
                                                        new Claim(ClaimTypes.Role, "employee"),
                                                        new Claim(ClaimTypes.NameIdentifier, "test-user")
                                                    };

                                var user = new ClaimsIdentity(claims, "jwt");

                                context.CurrentUser = new ClaimsPrincipal(user);
                            });
                    });

            this.Browser = new Browser(bootstrapper);
        }
    }
}
