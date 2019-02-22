namespace Domain.Linnapps.Tests.VatCodeSpecs
{
    using System;

    using FluentAssertions;

    using Linn.Common.Domain.Exceptions;

    using NUnit.Framework;

    public class WhenUpdatingVatCodeWithInvalidCode : ContextBase
    {
        private Action action;

        [SetUp]
        public void SetUp()
        {
            this.action = () => this.Sut.Update(string.Empty, "UK VAT ZERO RATE", 0, "REASON", 5, "Y");
        }

        [Test]
        public void ShouldThrowexception()
        {
            this.action.Should().Throw<DomainException>();
        }
    }
}