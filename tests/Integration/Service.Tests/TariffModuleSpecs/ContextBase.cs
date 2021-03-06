namespace Linn.Products.Service.Tests.TariffModuleSpecs
{
    using System.Collections.Generic;
    using System.Security.Claims;

    using Linn.Common.Facade;
    using Linn.Products.Domain;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Facade.ResourceBuilders;
    using Linn.Products.Facade.Services;
    using Linn.Products.Resources;
    using Linn.Products.Service.Modules;
    using Linn.Products.Service.ResponseProcessors;

    using Nancy.Testing;

    using NSubstitute;

    using NUnit.Framework;

    public abstract class ContextBase : NancyContextBase
    {
        protected ITariffFacadeService TariffService { get; private set; }

        protected IAuthorisationService AuthorisationService { get; private set; }

        [SetUp]
        public void EstablishContext()
        {
            this.TariffService = Substitute.For<ITariffFacadeService>();
            this.AuthorisationService = Substitute.For<IAuthorisationService>();
            this.AuthorisationService.HasPermissionFor(AuthorisedAction.TariffAdmin, Arg.Any<IEnumerable<string>>())
                .Returns(true);
            var bootstrapper = new ConfigurableBootstrapper(
                with =>
                {
                    with.Dependency(this.TariffService);
                    with.Dependency<IResourceBuilder<ResponseModel<Tariff>>>(new TariffResourceBuilder());
                    with.Dependency(this.AuthorisationService);
                    with.Dependency<IResourceBuilder<ResponseModel<IEnumerable<Tariff>>>>(new TariffsResourceBuilder());
                    with.Dependency<IResourceBuilder<ResponseModel<TariffsReallocator>>>(new TariffsReallocatorResourceBuilder());
                    with.Module<TariffModule>();
                    with.ResponseProcessor<TariffResponseProcessor>();
                    with.ResponseProcessor<TariffsResponseProcessor>();
                    with.ResponseProcessor<TariffsReallocatorResponseProcessor>();
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
