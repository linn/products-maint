namespace Linn.Products.Domain.Tests.WEEEReports
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using FluentAssertions;
    using FluentAssertions.Extensions;

    using Linn.Common.Reporting.Models;

    using NUnit.Framework;

    public class WhenGettingGermanWeeeReport : ContextBase
    {
        private IEnumerable<ResultsModel> result;

        [SetUp]
        public void SetUp()
        {
            this.result = this.Sut.GetGermanWeeeReport(20.March(2020), 20.March(2020));
        }

        [Test]
        public void ShouldGetResults()
        {
            this.result.Should().HaveCount(3);
            var weee = this.result.First();
            weee.GetGridTextValue(0, 0).Should().Be("P1");
            weee.GetGridTextValue(0, 1).Should().Be("DESC1");
            weee.GetGridValue(0, 2).Should().Be(2);
            weee.GetGridValue(0, 3).Should().Be((decimal)4.25);
            weee.GetGridTextValue(1, 0).Should().Be("P2");
            weee.GetGridTextValue(1, 1).Should().Be("DESC2");
            weee.GetGridValue(1, 2).Should().Be(1);
            weee.GetGridValue(1, 3).Should().Be((decimal)2.25);

            var packaging = this.result.ElementAt(1);
            packaging.GetGridTextValue(0, 0).Should().Be("P3");
            packaging.GetGridTextValue(0, 1).Should().Be("DESC3");
            packaging.GetGridValue(0, 2).Should().Be(1);

            var cables = this.result.Last();
            cables.GetGridTextValue(0, 0).Should().Be("P4");
            cables.GetGridTextValue(0, 1).Should().Be("DESC4");
            cables.GetGridValue(0, 2).Should().Be(1);
        }
    }
}
