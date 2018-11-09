namespace Linn.Products.Service.Tests.SACoreTypesModuleSpecs
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
        protected IFacadeService<SACoreType, int, SACoreTypeResource> SACoreTypeService { get; set; }

        [SetUp]
        public void EstablishContext()
        {
            this.SACoreTypeService = Substitute.For<IFacadeService<SACoreType, int, SACoreTypeResource>>();

            var bootstrapper = new ConfigurableBootstrapper(
                with =>
                    {
                        with.Dependency(this.SACoreTypeService);
                        with.Dependency<IResourceBuilder<SACoreType>>(new SACoreTypeResourceBuilder());
                        with.Dependency<IResourceBuilder<IEnumerable<SACoreType>>>(new SACoreTypesResourceBuilder());
                        with.Module<SACoreTypesModule>();
                        with.ResponseProcessor<SACoreTypeResponseProcessor>();
                        with.ResponseProcessor<SACoreTypesResponseProcessor>();
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
