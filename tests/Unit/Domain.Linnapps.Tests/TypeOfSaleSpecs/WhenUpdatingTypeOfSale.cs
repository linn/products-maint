namespace Linn.Products.Domain.Linnapps.Tests.TypeOfSaleSpecs
{
    using FluentAssertions;

    using NUnit.Framework;

    public class WhenUpdatingTypeOfSale : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            this.Sut.Update("DL", "NEW DESCRIPTION", "NOM", "DEPT", "N");
        }

        [Test]
        public void ShouldUpdate()
        {
            this.Sut.Description.Should().Be("NEW DESCRIPTION");
            this.Sut.Nominal.Should().Be("NOM");
            this.Sut.Department.Should().Be("DEPT");
            this.Sut.RealSale.Should().Be("N");
        }
    }
}
