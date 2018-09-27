namespace Linn.Products.Domain.Tests.CartonDetailsReportServiceSpecs
{
    using System.Collections.Generic;
    using System.Linq;

    using FluentAssertions;

    using NSubstitute;

    using NUnit.Framework;

    public class WhenGettingReport : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            this.CartonRepository.GetCartons()
                .Returns(new List<Carton>
                             {
                                 new Carton("c1", 1, 2.1, 3) { Description = "c1 desc" },
                                 new Carton("c2", 4, 5, 6)
                             });

            this.Results = this.Sut.GetCartonsReport();
        }

        [Test]
        public void ShouldReturnResults()
        {
            this.Results.ReportTitle.DisplayValue.Should().Be("Carton Details");
            this.Results.GetRowValues().Should().HaveCount(2);
            this.Results.Rows.First(a => a.RowIndex == 0).RowTitle.Should().Be("c1");
            this.Results.GetGridTextValue(0, 0).Should().Be("c1 desc");
            this.Results.GetGridValue(0, 1).Should().Be(3m);
            this.Results.GetGridValue(0, 2).Should().Be(1m);
            this.Results.GetGridValue(0, 3).Should().Be(2.1m);
        }
    }
}
