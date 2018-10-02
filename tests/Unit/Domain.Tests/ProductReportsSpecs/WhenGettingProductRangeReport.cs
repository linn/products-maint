namespace Linn.Products.Domain.Tests.ProductReportsSpecs
{
    using System.Collections.Generic;
    using System.Linq;

    using FluentAssertions;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenGettingProductRangeReport : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            this.ProductRangeRepository.GetProductRanges()
                .Returns(new List<ProductRange>
                             {
                                 new ProductRange("pr 1") { Id = 1, Description = "pr 1 desc" },
                                 new ProductRange("pr 2") { Id = 2, Description = "pr 2 desc" },
                                 new ProductRange("pr 3") { Id = 3, Description = "pr 3 desc", PhasedOutOn = 1.October(2018) }
                             });

            this.Results = this.Sut.GetProductRangeReport();
        }

        [Test]
        public void ShouldReturnResults()
        {
            this.Results.ReportTitle.DisplayValue.Should().Be("Product Ranges");
            this.Results.GetRowValues().Should().HaveCount(2);
            this.Results.Rows.First(a => a.RowIndex == 0).RowTitle.Should().Be("1");
            this.Results.GetGridTextValue(0, 0).Should().Be("pr 1");
            this.Results.GetGridTextValue(0, 1).Should().Be("pr 1 desc");
        }
    }
}
