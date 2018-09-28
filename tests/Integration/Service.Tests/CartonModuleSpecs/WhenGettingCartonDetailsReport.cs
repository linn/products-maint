namespace Linn.Products.Service.Tests.CartonModuleSpecs
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

    public class WhenGettingCartonDetailsReport : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            var results = new ResultsModel(new[] { "col1 " });
            this.CartonReportsService.GetCartonDetails()
                .Returns(new SuccessResult<ResultsModel>(results)
                             {
                                 Data = new ResultsModel { ReportTitle = new NameModel("cartons") }
                             });

            this.Response = this.Browser.Get(
                "/products/reports/carton-details",
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
            this.CartonReportsService.Received().GetCartonDetails();
        }

        [Test]
        public void ShouldReturnResource()
        {
            var resource = this.Response.Body.DeserializeJson<ReportReturnResource>();
            resource.ReportResults.First().title.displayString.Should().Be("cartons");
        }
    }
}