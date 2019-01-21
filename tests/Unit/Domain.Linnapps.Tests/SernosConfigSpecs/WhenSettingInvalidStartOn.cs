namespace Domain.Linnapps.Tests.SernosConfigSpecs
{
    using System;

    using FluentAssertions;

    using Linn.Common.Domain.Exceptions;

    using NUnit.Framework;

    public class WhenSettingInvalidStartOn : ContextBase
    {
        private Action action;

        [SetUp]
        public void SetUp()
        {
            this.action = () => this.Sut.SetStartOn("Wrong");
        }

        [Test]
        public void ShouldThrowException()
        {
            this.action.Should().Throw<DomainException>();
        }
    }
}
