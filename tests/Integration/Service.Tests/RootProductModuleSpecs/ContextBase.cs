namespace Linn.Products.Service.Tests.RootProductModuleSpecs
{
    using System.Collections.Generic;
    using System.Security.Claims;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Domain.Linnapps.Models;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Domain.Linnapps.RemoteServices;
    using Linn.Products.Facade.ResourceBuilders;
    using Linn.Products.Facade.Services;
    using Linn.Products.Resources;
    using Linn.Products.Service.Modules;
    using Linn.Products.Service.ResponseProcessors;
    using Linn.Products.Service.Tests;

    using Nancy.Testing;

    using NSubstitute;

    using NUnit.Framework;

    public abstract class ContextBase : NancyContextBase
    {
        protected IFacadeService<RootProduct, string, RootProductResource, RootProductResource> RootProductService { get; private set; }
        [SetUp]
        public void EstablishContext()
        {
            this.RootProductService = Substitute.For<IFacadeService<RootProduct, string, RootProductResource, RootProductResource>>();

            var bootstrapper = new ConfigurableBootstrapper(
                with =>
                {
                    with.Dependency(this.RootProductService);
                    with.Dependency<IResourceBuilder<RootProduct>>(new RootProductResourceBuilder());
                    with.Dependency<IResourceBuilder<IEnumerable<RootProduct>>>(new RootProductsResourceBuilder());
                    with.Module<RootProductModule>();
                    with.ResponseProcessor<RootProductResponseProcessor>();
                    with.ResponseProcessor<RootProductsResponseProcessor>();
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