namespace Linn.Products.Service.Tests.SerialNumberModuleSpecs
{
    using System.Collections.Generic;
    using System.Security.Claims;

    using Linn.Common.Facade;
    using Linn.Products.Domain;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Facade.ResourceBuilders;
    using Linn.Products.Facade.Services;
    using Linn.Products.Service.Modules;
    using Linn.Products.Service.ResponseProcessors;

    using Nancy.Testing;

    using NSubstitute;

    using NUnit.Framework;

    public abstract class ContextBase : NancyContextBase
    {
        protected ISerialNumberFacadeService SerialNumberService { get; private set; }

        protected IAuthorisationService AuthorisationService { get; private set; }

        [SetUp]
        public void EstablishContext()
        {
            this.SerialNumberService = Substitute.For<ISerialNumberFacadeService>();
            this.AuthorisationService = Substitute.For<IAuthorisationService>();
            this.AuthorisationService.HasPermissionFor(
                AuthorisedAction.SerialNumberAdmin,
                Arg.Any<IEnumerable<string>>()).Returns(true);

            var bootstrapper = new ConfigurableBootstrapper(
                with =>
                    {
                        with.Dependency(this.SerialNumberService);
                        with.Dependency(this.AuthorisationService);
                        with.Dependency<IResourceBuilder<ResponseModel<SerialNumber>>>(new SerialNumberResourceBuilder());
                        with.Dependency<IResourceBuilder<IEnumerable<SerialNumber>>>(new SerialNumbersResourceBuilder());
                        with.Module<SerialNumberModule>();
                        with.ResponseProcessor<SerialNumberResponseProcessor>();
                        with.ResponseProcessor<SerialNumbersResponseProcessor>();
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
