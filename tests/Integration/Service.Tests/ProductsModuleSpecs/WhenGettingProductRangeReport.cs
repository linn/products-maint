namespace Linn.Products.Service.Tests.ProductsModuleSpecs
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

    public class WhenGettingProductRangeReport : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            var results = new ResultsModel(new[] { "col1 " });
            this.ProductsReportsService.GetProductRanges(true)
                .Returns(new SuccessResult<ResultsModel>(results)
                             {
                                 Data = new ResultsModel { ReportTitle = new NameModel("title") }
                             });

            this.Response = this.Browser.Get(
                "/products/reports/product-ranges",
                with =>
                {
                    with.Header("Accept", "application/json");
                    with.Query("includePhasedOut", "true");
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
            this.ProductsReportsService.Received().GetProductRanges(true);
        }

        [Test]
        public void ShouldReturnResource()
        {
            var resource = this.Response.Body.DeserializeJson<ReportReturnResource>();
            resource.ReportResults.First().title.displayString.Should().Be("title");
        }
    }
}