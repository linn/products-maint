namespace Linn.Products.Domain.Tests.WEEEReports
{
    using FluentAssertions;
    using FluentAssertions.Extensions;

    using Linn.Common.Reporting.Models;

    using NUnit.Framework;

    public class WhenGettingUkWeeeReport : ContextBase
    {
        private ResultsModel results;

        [SetUp]
        public void SetUp()
        {
            this.results = this.Sut.GetUkWEEEReport(19.March(2020), 19.March(2020));
        }

        [Test]
        public void ShouldReturnResults()
        {
            this.results.ReportTitle.DisplayValue.Contains("UK WEEE Report");
            this.results.GetRowValues().Should().HaveCount(2);
            this.results.GetGridTextValue(0, 0).Should().Be("P1");
            this.results.GetGridTextValue(0, 1).Should().Be("DESC1");
            this.results.GetGridValue(0, 2).Should().Be(2);
            this.results.GetGridValue(0, 3).Should().Be(4);
            this.results.GetGridTextValue(1, 0).Should().Be("P2");
            this.results.GetGridTextValue(1, 1).Should().Be("DESC2");
            this.results.GetGridValue(1, 2).Should().Be(1);
            this.results.GetGridValue(1, 3).Should().Be(2);
        }
    }
}