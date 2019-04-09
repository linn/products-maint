namespace Linn.Products.Domain.Linnapps.Tests.SaHoldStorySpecs
{
    using System;

    using FluentAssertions;

    using NUnit.Framework;

    public class WhenUpdatingHoldStory : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            this.Sut.Update(new DateTime(), "test", new Employee { Id = 1, FullName = "Employee" });
        }

        [Test]
        public void ShouldUpdate()
        {
            this.Sut.ReasonFinished.Should().Be("test");
        }
    }
}
