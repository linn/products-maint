namespace Linn.Products.Domain.Linnapps.Tests.SernosNoteSpecs
{
    using System;

    using FluentAssertions;

    using Linn.Common.Domain.Exceptions;

    using NUnit.Framework;

    public class WhenUpdatingSernosNoteWithInvalidNote : ContextBase
    {
        private Action action;

        [SetUp]
        public void SetUp()
        {
            this.action = () => this.Sut.Update(string.Empty, "new sernos group", 2, 2, "new trans code");
        }

        [Test]
        public void ShouldThrowException()
        {
            this.action.Should().Throw<DomainException>();
        }
    }
}