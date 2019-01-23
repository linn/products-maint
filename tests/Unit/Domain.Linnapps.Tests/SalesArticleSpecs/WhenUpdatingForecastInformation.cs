namespace Domain.Linnapps.Tests.SalesArticleSpecs
{
    using FluentAssertions;
    using FluentAssertions.Extensions;

    using NUnit.Framework;

    public class WhenUpdatingForecastInformation : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            this.Sut.UpdateForecastInformation("Y", 1.December(2019), null, 12);
        }

        [Test]
        public void ShouldUpdateArticle()
        {
            this.Sut.ForecastFromDate.Should().Be(1.December(2019));
            this.Sut.ForecastToDate.Should().BeNull();
            this.Sut.ForecastType.Should().Be("Y");
            this.Sut.PercentageOfRootProductSales.Should().Be(12);
        }
    }
}
