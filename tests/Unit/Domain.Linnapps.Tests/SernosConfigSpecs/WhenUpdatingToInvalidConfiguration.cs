namespace Domain.Linnapps.Tests.SernosConfigSpecs
{
    using System;

    using FluentAssertions;

    using Linn.Products.Domain.Linnapps.Exceptions;

    using NUnit.Framework;

    public class WhenUpdatingToInvalidConfiguration : ContextBase
    {
        private Action action;

        [SetUp]
        public void SetUp()
        {
            this.action = () => this.Sut.Update("Y", null, 22);
        }

        [Test]
        public void ShouldThrowException()
        {
            this.action.Should().Throw<DomainException>();
        }
    }
}
