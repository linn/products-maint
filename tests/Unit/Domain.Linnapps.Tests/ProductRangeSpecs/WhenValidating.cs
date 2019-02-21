namespace Linn.Products.Domain.Linnapps.Tests.ProductRangeSpecs
{
    using System;

    using FluentAssertions;

    using Linn.Common.Domain.Exceptions;

    using NUnit.Framework;

    public class WhenValidating : ContextBase
    {
        private Action action;

        [SetUp]
        public void SetUp()
        {
            this.Sut.RangeName = "valid name";
            this.Sut.RangeDescription = "valid description";
            this.action = () => this.Sut.ValidateProductRange();
        }

        [Test]
        public void ShouldNotThrowException()
        {
            this.action.Should().NotThrow<DomainException>();
        }
    }
}
