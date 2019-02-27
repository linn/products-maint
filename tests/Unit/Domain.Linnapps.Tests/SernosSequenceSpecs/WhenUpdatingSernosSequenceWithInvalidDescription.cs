namespace Linn.Products.Domain.Linnapps.Tests.SernosSequenceSpecs
{
    using System;

    using FluentAssertions;
    using FluentAssertions.Extensions;

    using Linn.Common.Domain.Exceptions;

    using NUnit.Framework;

    public class WhenUpdatingSernosSequenceWithInvalidDescription : ContextBase
    {
        private Action action;

        [SetUp]
        public void SetUp()
        {
            this.action = () => this.Sut.Update("KRYSTAL", string.Empty, 501, 20.February(2019));
        }

        [Test]
        public void ShouldUpdate()
        {
            this.action.Should().Throw<DomainException>();
        }
    }
}