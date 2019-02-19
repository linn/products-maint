namespace Linn.Products.Service.Tests.SalesArticleReportsModuleSpecs
{
    using System.Collections.Generic;

    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Common.Reporting.Models;

    using Nancy;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenGettingCoreTypesCsvReport : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            var results = new ResultsModel(new[] { "col1 " });
            this.SalesArticleReportService.GetSalesArticleCoreTypesCsv()
                .Returns(new SuccessResult<IEnumerable<IEnumerable<string>>>(new List<List<string>>()));

            this.Response = this.Browser.Get(
                "/products/reports/sales-article-core-types/export",
                with => { }).Result;
        }

        [Test]
        public void ShouldReturnOk()
        {
            this.Response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public void ShouldCallService()
        {
            this.SalesArticleReportService.Received().GetSalesArticleCoreTypesCsv();
        }
    }
}