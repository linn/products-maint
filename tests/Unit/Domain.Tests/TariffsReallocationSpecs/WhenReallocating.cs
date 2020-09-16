namespace Linn.Products.Domain.Tests.TariffsReallocationSpecs
{
    using FluentAssertions;
    using NUnit.Framework;

    public class WhenReallocating : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            this.Result = this.TariffNumberReallocationService.Reallocate(118, 59);
        }

        [Test]
        public void ShouldUpdateTariffIdOfArticles()
        {
            this.Result.Count.Should().Be(3);
        }
    }
}
