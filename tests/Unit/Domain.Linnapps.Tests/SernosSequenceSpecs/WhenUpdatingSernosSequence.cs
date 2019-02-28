namespace Linn.Products.Domain.Linnapps.Tests.SernosSequenceSpecs
{
    using FluentAssertions;
    using FluentAssertions.Extensions;

    using NUnit.Framework;

    public class WhenUpdatingSernosSequence : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            this.Sut.Update("KRYSTAL", "CD MECHANISM", 501, 20.February(2019));
        }

        [Test]
        public void ShouldUpdate()
        {
            this.Sut.Description.Should().Be("CD MECHANISM");
            this.Sut.NextSerialNumber.Should().Be(501);
            this.Sut.DateClosed.Should().Be(20.February(2019));
        }
    }
}