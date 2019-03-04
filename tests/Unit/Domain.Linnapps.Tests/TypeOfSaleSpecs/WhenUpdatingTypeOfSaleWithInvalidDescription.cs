namespace Linn.Products.Domain.Linnapps.Tests.TypeOfSaleSpecs
{
    using System;

    using FluentAssertions;

    using Linn.Common.Domain.Exceptions;

    using NUnit.Framework;

    public class WhenUpdatingTypeOfSaleWithInvalidDescription : ContextBase
    {
        private Action action;

        [SetUp]
        public void SetUp()
        {
            this.action = () => this.Sut.Update("DL", string.Empty, "NOM", "DEPT", "N");
        }

        [Test]
        public void ShouldThrowexception()
        {
            this.action.Should().Throw<DomainException>();
        }
    }
}
