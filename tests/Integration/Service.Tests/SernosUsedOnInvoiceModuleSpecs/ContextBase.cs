namespace Linn.Products.Service.Tests.SernosUsedOnInvoiceModuleSpecs
{
    using System.Collections.Generic;
    using System.Security.Claims;

    using Linn.Common.Facade;
    using Linn.Common.Reporting.Models;
    using Linn.Products.Domain.Linnapps.Reports;
    using Linn.Products.Facade.ResourceBuilders;
    using Linn.Products.Facade.Services;
    using Linn.Products.Service.Modules;
    using Linn.Products.Service.Reports;
    using Linn.Products.Service.ResponseProcessors;
    using Linn.Products.Service.Tests;

    using Nancy.Testing;

    using NSubstitute;

    using NUnit.Framework;

    public abstract class ContextBase : NancyContextBase
    {
        protected ISernosUsedOnInvoiceReportService ReportService { get; private set; }

        [SetUp]
        public void EstablishContext()
        {
            this.ReportService = Substitute.For<ISernosUsedOnInvoiceReportService>();

            var bootstrapper = new ConfigurableBootstrapper(
                with =>
                {
                    with.Dependency(this.ReportService);
                    with.Dependency<IResourceBuilder<ResultsModel>>(new ResultsModelResourceBuilder());
                    with.Dependency<ISernosUsedOnInvoiceFacade>(new SernosUsedOnInvoiceFacade(this.ReportService));
                    with.Module<SernosUsedOnInvoiceModule>();
                    with.ResponseProcessor<ResultsModelJsonResponseProcessor>();
                    with.ResponseProcessor<IEnumerableCsvResponseProcessor>();

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