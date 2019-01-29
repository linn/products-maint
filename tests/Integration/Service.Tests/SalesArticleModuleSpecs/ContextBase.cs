namespace Linn.Products.Service.Tests.SalesArticleModuleSpecs
{
    using System.Collections.Generic;
    using System.Security.Claims;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Domain.Linnapps.RemoteServices;
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
        protected ISalesArticleService SalesArticleService { get; private set; }

        protected IFacadeService<SalesArticle, string, SalesArticleResource> SalesArticleForecastService { get; private set; }

        [SetUp]
        public void EstablishContext()
        {
            this.SalesArticleService = Substitute.For<ISalesArticleService>();
            this.SalesArticleForecastService = Substitute.For<IFacadeService<SalesArticle, string, SalesArticleResource>>();

            var bootstrapper = new ConfigurableBootstrapper(
                with =>
                {
                    with.Dependency(this.SalesArticleService);
                    with.Dependency(this.SalesArticleForecastService);
                    with.Dependency<IResourceBuilder<SalesArticle>>(new SalesArticleResourceBuilder());
                    with.Dependency<IResourceBuilder<IEnumerable<SalesArticle>>>(new SalesArticlesResourceBuilder());
                    with.Module<SalesArticleModule>();
                    with.ResponseProcessor<SalesArticleResponseProcessor>();
                    with.ResponseProcessor<SalesArticlesResponseProcessor>();
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