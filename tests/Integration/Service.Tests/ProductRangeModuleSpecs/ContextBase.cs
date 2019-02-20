namespace Linn.Products.Service.Tests.ProductRangeModuleSpecs
{
    using System.Collections.Generic;
    using System.Security.Claims;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Facade.ResourceBuilders;
    using Linn.Products.Resources;
    using Linn.Products.Service.Modules;
    using Linn.Products.Service.ResponseProcessors;
    using Linn.Products.Service.Tests;

    using Nancy.Testing;

    using NSubstitute;

    using NUnit.Framework;

    public abstract class ContextBase : NancyContextBase
    {
        protected IFacadeService<ProductRange, int, ProductRangeResource, ProductRangeUpdateResource> ProductRangeService { get; private set; }

        [SetUp]
        public void EstablishContext()
        {
            this.ProductRangeService = Substitute.For<IFacadeService<ProductRange, int, ProductRangeResource, ProductRangeUpdateResource>>();

            var bootstrapper = new ConfigurableBootstrapper(
                with =>
                {
                    with.Dependency(this.ProductRangeService);
                    with.Dependency<IResourceBuilder<ProductRange>>(new ProductRangeResourceBuilder());
                    with.Dependency<IResourceBuilder<IEnumerable<ProductRange>>>(new ProductRangesResourceBuilder());
                    with.Module<ProductRangeModule>();
                    with.ResponseProcessor<ProductRangeResponseProcessor>();
                    with.ResponseProcessor<ProductRangesResponseProcessor>();
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