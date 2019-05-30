namespace Linn.Products.Service.Tests.VatCodesModuleSpecs
{
    using System.Collections.Generic;
    using System.Security.Claims;

    using Linn.Common.Facade;
    using Linn.Products.Domain;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Facade.Models;
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
        protected IFacadeService<VatCode, string, VatCodeResource, VatCodeResource> VatCodeService { get; private set; }
        protected IAuthorisationService AuthorisationService { get; private set; }


        [SetUp]
        public void EstablishContext()
        {
            this.VatCodeService = Substitute.For<IFacadeService<VatCode, string, VatCodeResource, VatCodeResource>>();
            this.AuthorisationService = Substitute.For<IAuthorisationService>();
            this.AuthorisationService.CanEditOrCreateVatCodes(Arg.Any<IEnumerable<string>>()).Returns(true);
            var bootstrapper = new ConfigurableBootstrapper(
                with =>
                {
                    with.Dependency(this.VatCodeService);
                    with.Dependency<IResourceBuilder<ResponseModel<VatCode>>>(new VatCodeResourceBuilder());
                    with.Dependency(this.AuthorisationService);
                    with.Dependency<IResourceBuilder<IEnumerable<VatCode>>>(new VatCodesResourceBuilder());
                    with.Module<VatCodeModule>();
                    with.ResponseProcessor<VatCodeResponseProcessor>();
                    with.ResponseProcessor<VatCodesResponseProcessor>();
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