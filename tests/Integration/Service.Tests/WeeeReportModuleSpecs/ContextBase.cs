namespace Linn.Products.Service.Tests.WeeeReportModuleSpecs
{
    using System.Collections.Generic;
    using System.Security.Claims;

    using Linn.Common.Facade;
    using Linn.Common.Reporting.Models;
    using Linn.Products.Facade.ResourceBuilders;
    using Linn.Products.Facade.Services;
    using Linn.Products.Service.Modules;
    using Linn.Products.Service.ResponseProcessors;

    using Nancy.Testing;

    using NSubstitute;

    using NUnit.Framework;

    public abstract class ContextBase : NancyContextBase
    {
        protected IWEEEReportsService WeeeReportsService { get; private set; }

        [SetUp]
        public void EstablishContext()
        {
            this.WeeeReportsService = Substitute.For<IWEEEReportsService>();

            var bootstrapper = new ConfigurableBootstrapper(
                with =>
                    {
                        with.Dependency(this.WeeeReportsService);
                        with.Dependency<IResourceBuilder<ResultsModel>>(new ResultsModelResourceBuilder());
                        with.Dependency<IResourceBuilder<IEnumerable<ResultsModel>>>(new ResultsModelsResourceBuilder());
                        with.Module<WEEEReportModule>();
                        with.ResponseProcessor<ResultsModelJsonResponseProcessor>();
                        with.ResponseProcessor<ResultsModelsJsonResponseProcessor>();

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
