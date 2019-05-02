namespace Linn.Products.Service.Tests.SaHoldStoriesModuleSpecs
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

    public class WhenGettingByArticleNumber : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            var results = new ResultsModel(new[] { "col1 " });

            this.SaHoldStoriesReportService.GetHoldStoriesForSalesArticle("article")
                .Returns(new SuccessResult<ResultsModel>(results)
                             {
                                Data = new ResultsModel { ReportTitle = new NameModel("title") }
                            });

            this.Response = this.Browser.Get(
                "/products/reports/sa-hold-stories-for-sales-article/article",
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
            this.SaHoldStoriesReportService.Received().GetHoldStoriesForSalesArticle("article");
        }

        [Test]
        public void ShouldReturnResource()
        {
            var resource = this.Response.Body.DeserializeJson<ReportReturnResource>();
            resource.ReportResults.First().title.displayString.Should().Be("title");
        }
    }
}
