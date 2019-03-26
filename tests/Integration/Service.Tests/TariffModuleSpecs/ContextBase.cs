using System.Collections.Generic;
using System.Security.Claims;
using Linn.Common.Facade;
using Linn.Products.Domain.Linnapps.Products;
using Linn.Products.Facade.ResourceBuilders;
using Linn.Products.Resources;
using Linn.Products.Service.Modules;
using Linn.Products.Service.ResponseProcessors;
using Nancy.Testing;
using NSubstitute;
using NUnit.Framework;

namespace Linn.Products.Service.Tests.TariffModuleSpecs
{
    public abstract class ContextBase : NancyContextBase
    {
        protected IFacadeService<Tariff, int, TariffResource, TariffResource> TariffService { get; private set; }

        [SetUp]
        public void EstablishContext()
        {
            this.TariffService = Substitute.For<IFacadeService<Tariff, int, TariffResource, TariffResource>>();

            var bootstrapper = new ConfigurableBootstrapper(
                with =>
                {
                    with.Dependency(this.TariffService);
                    with.Dependency<IResourceBuilder<Tariff>>(new TariffResourceBuilder());
                    with.Dependency<IResourceBuilder<IEnumerable<Tariff>>>(new TariffsResourceBuilder());
                    with.Module<TariffModule>();
                    with.ResponseProcessor<TariffResponseProcessor>();
                    with.ResponseProcessor<TariffsResponseProcessor>();
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