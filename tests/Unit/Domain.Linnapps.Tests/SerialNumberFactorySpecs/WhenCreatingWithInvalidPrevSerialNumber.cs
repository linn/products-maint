namespace Linn.Products.Domain.Linnapps.Tests.SerialNumberFactorySpecs
{
    using System;

    using FluentAssertions;

    using Linn.Products.Domain.Linnapps.Exceptions;

    using NSubstitute.ReturnsExtensions;

    using NUnit.Framework;

    public class WhenCreatingWithInvalidPrevSerialNumber : ContextBase
    {
        private Action action;

        [SetUp]
        public void SetUp()
        {
            this.SalesArticleRepository.FindById("art").ReturnsNull();

            this.action = () => this.Sut.CreateSerialNumbers("RN ISSUED", "art", 1, 2, null, 4);
        }

        [Test]
        public void ShouldThrowException()
        {
            this.action.Should().Throw<InvalidSerialNumberTransactionException>().WithMessage("RN ISSUED and RN BUILT transactions must have a previous serial number");
        }
    }
}
