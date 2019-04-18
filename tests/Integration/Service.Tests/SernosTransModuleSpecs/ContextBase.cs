namespace Linn.Products.Service.Tests.SernosTransModuleSpecs
{
    using System.Collections.Generic;
    using System.Security.Claims;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
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
        protected IFacadeService<SernosTrans, string, SernosTransResource, SernosTransResource> SernosTransService { get; private set; }

        [SetUp]
        public void EstablishContext()
        {
            this.SernosTransService = Substitute.For<IFacadeService<SernosTrans, string, SernosTransResource, SernosTransResource>>();

            var bootstrapper = new ConfigurableBootstrapper(
                with =>
                {
                    with.Dependency(this.SernosTransService);
                    with.Dependency<IResourceBuilder<SernosTrans>>(new SernosTransResourceBuilder());
                    with.Dependency<IResourceBuilder<IEnumerable<SernosTrans>>>(new SernosTransesResourceBuilder());
                    with.Module<SernosTransModule>();
                    with.ResponseProcessor<SernosTransResponseProcessor>();
                    with.ResponseProcessor<SernosTransesResponseProcessor>();
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