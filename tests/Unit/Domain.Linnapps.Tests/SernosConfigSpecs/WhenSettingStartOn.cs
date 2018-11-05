namespace Domain.Linnapps.Tests.SernosConfigSpecs
{
    using FluentAssertions;

    using NUnit.Framework;

    public class WhenSettingStartOn : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            this.Sut.SetStartOn("Any");
        }

        [Test]
        public void ShouldSetStartOn()
        {
            this.Sut.StartOn.Should().Be("ANY");
        }
    }
}
