namespace Linn.Products.Domain.Tests.WEEEReports
{
    using System.Collections.Generic;
    using System.Linq;

    using FluentAssertions;
    using FluentAssertions.Extensions;

    using Linn.Common.Reporting.Models;

    using NUnit.Framework;

    public class WhenGettingUkWeeeReport : ContextBase
    {
        private IEnumerable<ResultsModel> results;

        [SetUp]
        public void SetUp()
        {
            this.results = this.Sut.GetUkWEEEReport(19.March(2020), 19.March(2020));
        }

        [Test]
        public void ShouldReturnResults()
        {
            this.results.Should().HaveCount(2);
            var weee = this.results.First();
            weee.ReportTitle.DisplayValue.Contains("UK WEEE Report");
            weee.GetRowValues().Should().HaveCount(2);
            weee.GetGridTextValue(0, 0).Should().Be("P1");
            weee.GetGridTextValue(0, 1).Should().Be("DESC1");
            weee.GetGridValue(0, 2).Should().Be(2);
            weee.GetGridValue(0, 3).Should().Be(4);
            weee.GetGridTextValue(1, 0).Should().Be("P2");
            weee.GetGridTextValue(1, 1).Should().Be("DESC2");
            weee.GetGridValue(1, 2).Should().Be(1);
            weee.GetGridValue(1, 3).Should().Be(2);
        }
    }
}