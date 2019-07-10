namespace Linn.Products.Service.Tests.SalesArticleReportsModuleSpecs
{
    using System.Collections.Generic;
    using System.Linq;

    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Common.Reporting.Models;
    using Linn.Common.Reporting.Resources.ReportResultResources;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Resources;

    using Nancy;
    using Nancy.Testing;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenGettingByTariffCode : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            var results = new ResultsModel(new[] { "col1 " });
            this.SalesArticleReportService.GetSalesArticleByTariff(1).Returns(new SuccessResult<ResultsModel>(results)
            {
                Data = new ResultsModel { ReportTitle = new NameModel("sa") }
            });

            this.Response = this.Browser.Get(
                "/products/reports/sales-articles/get-by-tariff",
                with =>
                    {
                        with.Header("Accept", "application/json");
                        with.Query("tariffId", "1");
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
            this.SalesArticleReportService.Received().GetSalesArticleByTariff(1);
        }

        [Test]
        public void ShouldReturnResource()
        {
            var resource = this.Response.Body.DeserializeJson<ReportReturnResource>();
            resource.ReportResults.First().title.displayString.Should().Be("sa");
        }
    }
}