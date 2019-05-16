namespace Linn.Products.Domain.Linnapps.Tests.SerialNumberFactorySpecs
{
    using System;

    using FluentAssertions;

    using Linn.Products.Domain.Linnapps.Exceptions;

    using NSubstitute.ReturnsExtensions;

    using NUnit.Framework;

    public class WhenCreatingRnIssuedWithInvalidToSerialNumber : ContextBase
    {
        private Action action;

        [SetUp]
        public void SetUp()
        {
            this.SalesArticleRepository.FindById("art").ReturnsNull();

            this.action = () => this.Sut.CreateSerialNumbers("RN ISSUED", "art", 1, 2, 3, 4);
        }

        [Test]
        public void ShouldThrowException()
        {
            this.action.Should().Throw<InvalidSerialNumberTransactionException>().WithMessage("RN ISSUED and RN BUILT transactions can only be for a single serial number");
        }
    }
}
