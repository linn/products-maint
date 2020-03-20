namespace Linn.Products.Facade.Tests.WeeeReportServiceSpecs
{
    using System;

    using FluentAssertions;
    using FluentAssertions.Extensions;

    using Linn.Common.Facade;
    using Linn.Common.Reporting.Models;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenGettingUkWeeeReport : ContextBase
    {
        private IResult<ResultsModel> result;

        [SetUp]
        public void SetUp()
        {
            this.WeeeReports.GetUkWEEEReport(Arg.Any<DateTime>(), Arg.Any<DateTime>())
                .Returns(new ResultsModel { ReportTitle = new NameModel("title") });
            this.result = this.Sut.GetUkWeeeReport(19.March(2020), 19.March(2020));
        }

        [Test]
        public void ShouldGetResults()
        {
            this.WeeeReports.Received().GetUkWEEEReport(Arg.Any<DateTime>(), Arg.Any<DateTime>());
        }

        [Test]
        public void ShouldReturnResults()
        {
            this.result.Should().BeOfType<SuccessResult<ResultsModel>>();
            var dataResult = ((SuccessResult<ResultsModel>)this.result).Data;
            dataResult.ReportTitle.DisplayValue.Should().Be("title");
        }
    }
}