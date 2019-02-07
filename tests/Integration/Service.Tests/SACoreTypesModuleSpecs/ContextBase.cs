namespace Linn.Products.Service.Tests.SaCoreTypesModuleSpecs
{
    using System.Collections.Generic;
    using System.Security.Claims;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Facade.ResourceBuilders;
    using Linn.Products.Resources;
    using Linn.Products.Service.Modules;
    using Linn.Products.Service.ResponseProcessors;

    using Nancy.Testing;

    using NSubstitute;

    using NUnit.Framework;

    public abstract class ContextBase : NancyContextBase
    {
        protected IFacadeService<SaCoreType, int, SaCoreTypeResource, SaCoreTypeResource> SaCoreTypeService { get; set; }

        [SetUp]
        public void EstablishContext()
        {
            this.SaCoreTypeService = Substitute.For<IFacadeService<SaCoreType, int, SaCoreTypeResource, SaCoreTypeResource>>();

            var bootstrapper = new ConfigurableBootstrapper(
                with =>
                    {
                        with.Dependency(this.SaCoreTypeService);
                        with.Dependency<IResourceBuilder<SaCoreType>>(new SaCoreTypeResourceBuilder());
                        with.Dependency<IResourceBuilder<IEnumerable<SaCoreType>>>(new SaCoreTypesResourceBuilder());
                        with.Module<SaCoreTypesModule>();
                        with.ResponseProcessor<SaCoreTypeResponseProcessor>();
                        with.ResponseProcessor<SaCoreTypesResponseProcessor>();
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
