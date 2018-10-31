namespace Linn.Products.Service.Tests.SernosConfigModuleSpecs
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
    using Linn.Products.Service.Tests;

    using Nancy.Testing;

    using NSubstitute;

    using NUnit.Framework;

    public abstract class ContextBase : NancyContextBase
    {
        protected IFacadeService<SernosConfig, string, SernosConfigResource> SernosConfigService { get; private set; }

        [SetUp]
        public void EstablishContext()
        {
            this.SernosConfigService = Substitute.For<IFacadeService<SernosConfig, string, SernosConfigResource>>();

            var bootstrapper = new ConfigurableBootstrapper(
                with =>
                {
                    with.Dependency(this.SernosConfigService);
                    with.Dependency<IResourceBuilder<SernosConfig>>(new SernosConfigResourceBuilder());
                    with.Module<SernosConfigModule>();
                    with.ResponseProcessor<SernosConfigResponseProcessor>();
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