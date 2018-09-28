namespace Linn.Products.Domain.Tests.ProductReportsSpecs
{
    using System.Collections.Generic;
    using System.Linq;

    using FluentAssertions;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenGettingSalesProductsByRangeReport : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            var productRange = new ProductRange("1") { Id = 1 };
            this.SalesProductRepository.GetSalesProducts()
                .Returns(new List<SalesProduct>
                             {
                                 new SalesProduct("1") { Id = 1, Description = "1 desc", ProductRange = productRange },
                                 new SalesProduct("2") { Id = 2, Description = "2 desc", ProductRange = productRange },
                                 new SalesProduct("3") { Id = 3, Description = "3 desc", PhasedOutOn = 1.October(2018), ProductRange = productRange },
                                 new SalesProduct("4") { Id = 4, Description = "4 desc", ProductRange = new ProductRange("2") { Id = 2 } }
                             });

            this.Results = this.Sut.GetSalesProductByRangeReport(1);
        }

        [Test]
        public void ShouldReturnResults()
        {
            this.Results.ReportTitle.DisplayValue.Should().Be("Sales Products");
            this.Results.GetRowValues().Should().HaveCount(2);
            this.Results.Rows.First(a => a.RowIndex == 0).RowTitle.Should().Be("1");
            this.Results.GetGridTextValue(0, 0).Should().Be("1");
            this.Results.GetGridTextValue(0, 1).Should().Be("1 desc");
        }
    }
}
