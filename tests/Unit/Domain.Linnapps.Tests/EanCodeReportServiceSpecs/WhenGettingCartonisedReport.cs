namespace Linn.Products.Domain.Linnapps.Tests.EanCodeReportServiceSpecs
{
    using System.Collections.Generic;
    using System.Linq;

    using FluentAssertions;

    using Linn.Products.Domain.Linnapps.Products;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenGettingCartonisedReport : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            this.IncludePhasedOut = true;
            this.CartonisedOnly = true;

            this.SalesArticleService.GetByDiscountFamily("HIFI", this.IncludePhasedOut).Returns(
                new List<SalesArticle>
                    {
                        new SalesArticle { ArticleNumber = "a", InvoiceDescription = "aa", EanCode = "aaa", CartonType = "C1" },
                        new SalesArticle { ArticleNumber = "b", InvoiceDescription = "bb", EanCode = "bbb", CartonType = "C2" },
                        new SalesArticle { ArticleNumber = "c", InvoiceDescription = "c", EanCode = "c" }
                    });

            this.Results = this.Sut.GetEanCodeReport(this.IncludePhasedOut, this.CartonisedOnly);
        }

        [Test]
        public void ShouldReturnResults()
        {
            this.Results.ReportTitle.DisplayValue.Should().Be("Sales Article EAN Codes");
            this.Results.GetRowValues().Should().HaveCount(2);
            this.Results.Rows.First(a => a.RowIndex == 0).RowTitle.Should().Be("a");
            this.Results.GetGridTextValue(0, 0).Should().Be("aa");
            this.Results.GetGridTextValue(0, 1).Should().Be("aaa");
            this.Results.Rows.First(a => a.RowIndex == 1).RowTitle.Should().Be("b");
            this.Results.GetGridTextValue(1, 0).Should().Be("bb");
            this.Results.GetGridTextValue(1, 1).Should().Be("bbb");
        }
    }
}
