namespace Linn.Products.Domain.Linnapps.Tests.SalesArticleReportsSpecs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using FluentAssertions;

    using Linn.Products.Domain.Linnapps.Products;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenGettingCoreTypeReport : ContextBase
    {
        private List<SalesArticle> salesArticles;

        [SetUp]
        public void SetUp()
        {
            this.salesArticles = new List<SalesArticle>
                                     {
                                         new SalesArticle { ArticleNumber = "a1", InvoiceDescription = "a1d", SaCoreType = new SaCoreType(1, "one") },
                                         new SalesArticle { ArticleNumber = "b2", InvoiceDescription = "b2d", SaCoreType = new SaCoreType(2, "two") }
                                     };
            this.SalesArticleRepository.FilterBy(Arg.Any<Expression<Func<SalesArticle, bool>>>())
                .Returns(this.salesArticles.AsQueryable());

            this.Results = this.Sut.SalesArticleCoreTypeReport();
        }

        [Test]
        public void ShouldReturnResults()
        {
            this.Results.ReportTitle.DisplayValue.Should().Be("Sales Article Core Types");
            this.Results.GetRowValues().Should().HaveCount(2);
            this.Results.Rows.First(a => a.RowIndex == 0).RowTitle.Should().Be("a1");
            this.Results.Rows.First(a => a.RowIndex == 1).RowTitle.Should().Be("b2");
            this.Results.GetGridTextValue(0, 0).Should().Be("a1d");
            this.Results.GetGridTextValue(0, 1).Should().Be("one");
        }
    }
}
