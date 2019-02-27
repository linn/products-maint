namespace Linn.Products.Domain.Linnapps.Tests.ProductRangeSpecs
{
    using System;

    using FluentAssertions;

    using Linn.Common.Domain.Exceptions;

    using NUnit.Framework;

    public class WhenInvalid : ContextBase
    {
        private Action action;

        [SetUp]
        public void SetUp()
        {
            this.Sut.RangeDescription = "valid description but it has no name";
            this.action = () => this.Sut.ValidateProductRange();
        }

        [Test]
        public void ShouldThrowException()
        {
            this.action.Should().Throw<DomainException>();
        }
    }
}
