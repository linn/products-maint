namespace Domain.Linnapps.Tests.SalesArticleSpecs
{
    using FluentAssertions;
    using FluentAssertions.Extensions;

    using Linn.Products.Domain.Linnapps;

    using NUnit.Framework;

    public class WhenUpdatingForecastInformation : ContextBase
    {
        private SaCoreType coreType;

        [SetUp]
        public void SetUp()
        {
            this.coreType = new SaCoreType(1, "desc");

            this.Sut.Update("Y", 1.December(2019), null, 12, this.coreType);
        }

        [Test]
        public void ShouldUpdateArticle()
        {
            this.Sut.ForecastFromDate.Should().Be(1.December(2019));
            this.Sut.ForecastToDate.Should().BeNull();
            this.Sut.ForecastType.Should().Be("Y");
            this.Sut.PercentageOfRootProductSales.Should().Be(12);
            this.Sut.SaCoreType.CoreType.Should().Be(this.coreType.CoreType);
        }
    }
}
