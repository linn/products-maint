namespace Domain.Linnapps.Tests.SernosConfigSpecs
{
    using FluentAssertions;

    using NUnit.Framework;

    public class WhenSettingEmptyStartOn : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            this.Sut.SetStartOn(null);
        }

        [Test]
        public void ShouldSetStartOnToEmpty()
        {
            this.Sut.StartOn.Should().BeNull();
        }
    }
}
