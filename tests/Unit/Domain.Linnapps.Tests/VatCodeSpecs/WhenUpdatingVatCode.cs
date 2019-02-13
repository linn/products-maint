namespace Domain.Linnapps.Tests.VatCodeSpecs
{
    using FluentAssertions;

    using NUnit.Framework;

    public class WhenUpdatingVatCode : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            this.Sut.Update("UK VAT ZERO RATE", 0, "REASON");
        }

        [Test]
        public void ShouldUpdate()
        {
            this.Sut.Description.Should().Be("UK VAT ZERO RATE");
            this.Sut.Rate.Should().Be(0);
            this.Sut.Reason.Should().Be("REASON");
        }
    }
}
