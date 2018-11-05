namespace Domain.Linnapps.Tests.SernosConfigSpecs
{
    using FluentAssertions;

    using NUnit.Framework;

    public class WhenUpdatingConfiguration : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            this.Sut.Update("Y", 11, 22);
        }

        [Test]
        public void ShouldUpdate()
        {
            this.Sut.SerialNumbered.Should().Be("Y");
            this.Sut.NumberOfSernos.Should().Be(11);
            this.Sut.NumberOfBoxes.Should().Be(22);
        }
    }
}
