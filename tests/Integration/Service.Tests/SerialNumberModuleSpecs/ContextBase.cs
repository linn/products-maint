namespace Linn.Products.Service.Tests.SerialNumberModuleSpecs
{
    using System.Collections.Generic;
    using System.Security.Claims;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
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
        protected IFacadeService<SerialNumber, int, SerialNumberResource, SerialNumberResource> SerialNumberService { get; private set; }

        [SetUp]
        public void EstablishContext()
        {
            this.SerialNumberService = Substitute.For<IFacadeService<SerialNumber, int, SerialNumberResource, SerialNumberResource>>();

            var bootstrapper = new ConfigurableBootstrapper(
                with =>
                    {
                        with.Dependency(this.SerialNumberService);
                        with.Dependency<IResourceBuilder<SerialNumber>>(new SerialNumberResourceBuilder());
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
