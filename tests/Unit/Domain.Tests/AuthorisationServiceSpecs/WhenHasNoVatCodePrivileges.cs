﻿namespace Linn.Products.Domain.Tests.AuthorisationServiceSpecs
{
    using FluentAssertions;

    using NUnit.Framework;

    public class WhenHasNoVatCodePrivileges : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            this.HasPrivilegeResult = this.Sut.HasPermissionFor(AuthorisedAction.VatAdmin, this.Privileges);
        }

        [Test]
        public void ShouldReturnFalse()
        {
            this.HasPrivilegeResult.Should().BeFalse();
        }
    }
}
