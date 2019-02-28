namespace Linn.Products.Domain.Linnapps.Tests.SernosSequenceSpecs
{
    using System;

    using FluentAssertions;
    using FluentAssertions.Extensions;

    using Linn.Common.Domain.Exceptions;

    using NUnit.Framework;

    public class WhenUpdatingSernosSequenceWithInvalidSequenceName : ContextBase
    {
        private Action action;

        [SetUp]
        public void SetUp()
        {
            this.action = () => this.Sut.Update(string.Empty, "CD MECHANISM", 501, 20.February(2019));
        }

        [Test]
        public void ShouldUpdate()
        {
            this.action.Should().Throw<DomainException>();
        }
    }
}