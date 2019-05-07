namespace Linn.Products.Service.Tests.SernosUsedOnConsignmentModuleSpecs
{
    using System.Linq;

    using FluentAssertions;

    using Linn.Common.Reporting.Models;
    using Linn.Common.Reporting.Resources.ReportResultResources;
    using Linn.Products.Service.Tests.SernosUsedOnInvoiceModuleSpecs;

    using Nancy;
    using Nancy.Testing;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenGettingReportAndConsignmentNumber : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            var results = new ResultsModel(new[] { "col1 " });
            this.ReportService.GetReport(null, 1)
                .Returns(new ResultsModel() { ReportTitle = new NameModel("t") });

            this.Response = this.Browser.Get(
                "/products/reports/sernos-used-on-invoice",
                with =>
                    {
                        with.Header("Accept", "application/json");
                        with.Query("consignmentNumber", "1");
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
            this.ReportService.Received().GetReport(null, 1);
        }

        [Test]
        public void ShouldReturnResource()
        {
            var resource = this.Response.Body.DeserializeJson<ReportReturnResource>();
            resource.ReportResults.First().title.displayString.Should().Be("t");
        }
    }
}
