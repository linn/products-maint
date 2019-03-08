namespace Linn.Products.Service.Tests.SalesPackageModuleSpecs
{
    using System.Collections.Generic;
    using System.Security.Claims;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps.SalesPackages;
    using Linn.Products.Facade.ResourceBuilders;
    using Linn.Products.Resources;
    using Linn.Products.Service.Modules;
    using Linn.Products.Service.ResponseProcessors;

    using Nancy.Testing;

    using NSubstitute;

    using NUnit.Framework;

    public abstract class ContextBase : NancyContextBase
    {
        protected IFacadeService<SalesPackage, int, SalesPackageResource, SalesPackageResource> SalesPackageService { get; set; }

        [SetUp]
        public void EstablishContext()
        {
            this.SalesPackageService = Substitute.For<IFacadeService<SalesPackage, int, SalesPackageResource, SalesPackageResource>>();

            var bootstrapper = new ConfigurableBootstrapper(
                with =>
                    {
                        with.Dependency(this.SalesPackageService);
                        with.Dependency<IResourceBuilder<SalesPackage>>(new SalesPackageResourceBuilder());
                        with.Dependency<IResourceBuilder<IEnumerable<SalesPackage>>>(new SalesPackagesResourceBuilder());
                        with.Module<SalesPackageModule>();
                        with.ResponseProcessor<SalesPackageResponseProcessor>();
                        with.ResponseProcessor<SalesPackagesResponseProcessor>();
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
