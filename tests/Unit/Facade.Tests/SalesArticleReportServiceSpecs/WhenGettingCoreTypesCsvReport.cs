﻿namespace Linn.Products.Facade.Tests.SalesArticleReportServiceSpecs
{
    using System.Collections.Generic;
    using System.Linq;

    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Common.Reporting.Models;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenGettingCoreTypesCsvReport : ContextBase
    {
        private IResult<IEnumerable<IEnumerable<string>>> result;

        [SetUp]
        public void SetUp()
        {
            var results = new ResultsModel(new[] { "col" })
                              {
                                  ReportTitle = new NameModel("title"), RowHeader = "head"
                              };
            results.AddRow("row");
            results.SetGridTextValue(0, 0, "val");
            this.SalesArticleReports.SalesArticleCoreTypeReport()
                .Returns(results);
            this.result = this.Sut.GetSalesArticleCoreTypesCsv();
        }

        [Test]
        public void ShouldGetResults()
        {
            this.SalesArticleReports.Received().SalesArticleCoreTypeReport();
        }

        [Test]
        public void ShouldReturnResults()
        {
            this.result.Should().BeOfType<SuccessResult<IEnumerable<IEnumerable<string>>>>();
            var dataResult = ((SuccessResult<IEnumerable<IEnumerable<string>>>)this.result).Data.ToList();
            dataResult.Should().HaveCount(2);
            dataResult.First().Should().HaveCount(2);
            dataResult.First().First().Should().Be("head");
            dataResult.First().Last().Should().Be("col");

            dataResult.Last().Should().HaveCount(2);
            dataResult.Last().First().Should().Be("row");
            dataResult.Last().Last().Should().Be("val");
        }
    }
}
