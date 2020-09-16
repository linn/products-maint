namespace Linn.Products.Domain.Tests.TariffsReallocationSpecs
{
    using Linn.Common.Domain.Exceptions;
    using NUnit.Framework;

    public class WhenInvalidTariffNumber : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void ShouldUpdateTariffIdOfArticles()
        {
            Assert.Throws<DomainException>(() => this.TariffNumberReallocationService.Reallocate(0, 59));
        }
    }
}
