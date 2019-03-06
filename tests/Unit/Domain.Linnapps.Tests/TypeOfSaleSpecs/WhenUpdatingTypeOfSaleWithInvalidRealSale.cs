namespace Linn.Products.Domain.Linnapps.Tests.TypeOfSaleSpecs
{
    using System;

    using FluentAssertions;

    using Linn.Common.Domain.Exceptions;

    using NUnit.Framework;

    public class WhenUpdatingTypeOfSaleWithInvalidRealSale : ContextBase
    {
        private Action action;

        [SetUp]
        public void SetUp()
        {
            this.action = () => this.Sut.Update("DL", "NEW DESCRIPTION", "NOM", "DEPT", string.Empty);
        }

        [Test]
        public void ShouldThrowexception()
        {
            this.action.Should().Throw<DomainException>();
        }
    }
}
