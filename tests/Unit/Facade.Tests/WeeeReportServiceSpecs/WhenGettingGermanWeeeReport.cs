namespace Linn.Products.Facade.Tests.WeeeReportServiceSpecs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using FluentAssertions;
    using FluentAssertions.Extensions;

    using Linn.Common.Facade;
    using Linn.Common.Reporting.Models;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenGettingGermanWeeeReport : ContextBase
    {
        private IResult<IEnumerable<ResultsModel>> result;

        [SetUp]
        public void SetUp()
        {
            this.WeeeReports.GetGermanWeeeReport(Arg.Any<DateTime>(), Arg.Any<DateTime>()).Returns(
                new List<ResultsModel> { new ResultsModel { ReportTitle = new NameModel("title") } });
            this.result = this.Sut.GetGermanWeeeReport(19.March(2020), 19.March(2020));
        }

        [Test]
        public void ShouldGetResults()
        {
            this.WeeeReports.Received().GetGermanWeeeReport(Arg.Any<DateTime>(), Arg.Any<DateTime>());
        }

        [Test]
        public void ShouldReturnResults()
        {
            this.result.Should().BeOfType<SuccessResult<IEnumerable<ResultsModel>>>();
            var dataResult = ((SuccessResult<IEnumerable<ResultsModel>>)this.result).Data;
            dataResult.First().ReportTitle.DisplayValue.Should().Be("title");
        }
    }
}