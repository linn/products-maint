namespace Linn.Products.Service.Tests.SaHoldStoriesModuleSpecs
{
    using System.Collections.Generic;
    using System.Security.Claims;

    using Linn.Common.Facade;
    using Linn.Common.Nancy.Facade;
    using Linn.Common.Reporting.Models;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Domain.Linnapps.Reports;
    using Linn.Products.Domain.Linnapps.Repositories;
    using Linn.Products.Facade.ResourceBuilders;
    using Linn.Products.Resources;
    using Linn.Products.Service.Modules;
    using Linn.Products.Service.ResponseProcessors;

    using Microsoft.Extensions.DependencyModel;

    using Nancy.Testing;

    using NSubstitute;

    using NUnit.Framework;

    using ISaHoldStoriesReportService = Linn.Products.Facade.Services.ISaHoldStoriesReportService;

    public abstract class ContextBase : NancyContextBase
    {
        protected IFacadeService<SaHoldStory, int, SaHoldStoryResource, SaHoldStoryResource> SaHoldStoryService { get; set; }

        protected ISaHoldStoriesReportService SaHoldStoriesReportService { get; set; }

        [SetUp]
        public void EstablishContext()
        {
            this.SaHoldStoryService = Substitute.For<IFacadeService<SaHoldStory, int, SaHoldStoryResource, SaHoldStoryResource>>();
            this.SaHoldStoriesReportService = Substitute.For<ISaHoldStoriesReportService>();

            var bootstrapper = new ConfigurableBootstrapper(
                with =>
                    {
                        with.Dependency(this.SaHoldStoriesReportService);
                        with.Dependency(this.SaHoldStoryService);
                        with.Dependency<IResourceBuilder<IEnumerable<SaHoldStory>>>(new SaHoldStoriesResourceBuilder());
                        with.Dependency<IResourceBuilder<ResultsModel>>(new ResultsModelResourceBuilder());
                        with.Dependency<IResourceBuilder<SaHoldStory>>(new SaHoldStoryResourceBuilder());
                        with.Module<SaHoldStoriesModule>();
                        with.ResponseProcessor<SaHoldStoriesResponseProcessor>();
                        with.ResponseProcessor<SaHoldStoryResponseProcessor>();
                        with.ResponseProcessor<ResultsModelJsonResponseProcessor>();
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
