
namespace Linn.Products.Service.Tests.StockTriggerLevelReportModuleSpecs
{
    using System.Collections.Generic;
    using System.Linq;

    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Common.Reporting.Models;
    using Linn.Common.Reporting.Resources.ReportResultResources;

    using Nancy;
    using Nancy.Testing;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenGettingStockTriggerLevelReportAtLocation : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            var results = new ResultsModel(new[] { "col1 " });
            this.StockTriggerLevelsService.GetStockTriggerLevelsForPartAtLocation(2, "part-number")
                .Returns(new SuccessResult<ResultsModel>(results)
                            {
                                Data = new ResultsModel { ReportTitle = new NameModel("title") }
                            });

            this.Response = this.Browser.Get(
                "/products/reports/stock-trigger-levels/2/part-number",
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
            this.StockTriggerLevelsService.Received().GetStockTriggerLevelsForPartAtLocation(2, "part-number");
        }

        [Test]
        public void ShouldReturnResource()
        {
            var resource = this.Response.Body.DeserializeJson<ReportReturnResource>();
            resource.ReportResults.First().title.displayString.Should().Be("title");
        }
    }
}