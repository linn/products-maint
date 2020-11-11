namespace Linn.Products.Service.Tests.WeeeReportModuleSpecs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using FluentAssertions;
    using FluentAssertions.Extensions;

    using Linn.Common.Facade;
    using Linn.Common.Reporting.Models;
    using Linn.Common.Reporting.Resources.ReportResultResources;

    using Nancy;
    using Nancy.Testing;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenGettingUkWeeeReport : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            var results = new List<ResultsModel> { new ResultsModel { ReportTitle = new NameModel("Title") } };

            this.WeeeReportsService.GetUkWeeeReport(Arg.Any<DateTime>(), Arg.Any<DateTime>())
                .Returns(new SuccessResult<IEnumerable<ResultsModel>>(results));

            this.Response = this.Browser.Get(
                "/products/reports/weee/report",
                with =>
                    {
                        with.Header("Accept", "application/json");
                        with.Query("fromDate", 13.March(2020).ToString("O"));
                        with.Query("toDate", 13.March(2020).ToString("O"));
                        with.Query("countryCode", "GB");
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
            this.WeeeReportsService.Received().GetUkWeeeReport(Arg.Any<DateTime>(), Arg.Any<DateTime>());
        }

        [Test]
        public void ShouldReturnResource()
        {
            var resource = this.Response.Body.DeserializeJson<ReportReturnResource>();
            resource.ReportResults.First().title.displayString.Should().Be("Title");
        }
    }
}