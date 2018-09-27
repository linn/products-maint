namespace Domain.Linnapps.Tests.EanCodeReportServiceSpecs
{
    using System.Collections.Generic;
    using System.Linq;

    using FluentAssertions;

    using Linn.Products.Domain.Linnapps.Products;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenGettingReport : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            this.IncludePhasedOut = false;
            this.CartonisedOnly = false;

            this.SalesArticleService.GetByDiscountFamily("HIFI", this.IncludePhasedOut).Returns(
                new List<SalesArticle>
                    {
                        new SalesArticle { ArticleNumber = "a", InvoiceDescription = "aa", EanCode = "aaa" },
                        new SalesArticle { ArticleNumber = "b", InvoiceDescription = "b", EanCode = "b" },
                        new SalesArticle { ArticleNumber = "c", InvoiceDescription = "c", EanCode = "c" }
                    });

            this.Results = this.Sut.GetEanCodeReport(this.IncludePhasedOut, this.CartonisedOnly);
        }

        [Test]
        public void ShouldReturnResults()
        {
            this.Results.ReportTitle.DisplayValue.Should().Be("Sales Article EAN Codes");
            this.Results.GetRowValues().Should().HaveCount(3);
            this.Results.Rows.First(a => a.RowIndex == 0).RowTitle.Should().Be("a");
            this.Results.GetGridTextValue(0, 0).Should().Be("aa");
            this.Results.GetGridTextValue(0, 1).Should().Be("aaa");
        }
    }
}
