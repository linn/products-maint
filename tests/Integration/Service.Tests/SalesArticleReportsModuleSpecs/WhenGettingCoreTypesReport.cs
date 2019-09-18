namespace Linn.Products.Service.Tests.SalesArticleReportsModuleSpecs
{
    using System.Linq;

    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Common.Reporting.Models;
    using Linn.Common.Reporting.Resources.ReportResultResources;

    using Nancy;
    using Nancy.Testing;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenGettingCoreTypesReport : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            var results = new ResultsModel { ReportTitle = new NameModel("t") };
            this.SalesArticleReportService.GetSalesArticleCoreTypes()
                .Returns(new SuccessResult<ResultsModel>(results));

            this.Response = this.Browser.Get(
                "/products/reports/sales-article-core-types",
                with =>
                {
                    with.Header("Accept", "application/json");
                }).Result;
        }

        [Test]
        public void ShouldReturnOk()
        {
            this.Response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public void ShouldCallService()
        {
            this.SalesArticleReportService.Received().GetSalesArticleCoreTypes();
        }

        [Test]
        public void ShouldReturnResource()
        {
            var resource = this.Response.Body.DeserializeJson<ReportReturnResource>();
            resource.ReportResults.First().title.displayString.Should().Be("t");
        }
    }
}