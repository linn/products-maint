﻿namespace Linn.Products.Domain.Tests.AuthorisationServiceSpecs
{
    using FluentAssertions;

    using NUnit.Framework;

    public class WhenHasVatCodePrivileges : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            this.Privileges.Add("finance.admin");
            this.HasPrivilegeResult = this.Sut.CanEditOrCreateVatCodes(this.Privileges);
        }

        [Test]
        public void ShouldReturnTrue()
        {
            this.HasPrivilegeResult.Should().BeTrue();
        }
    }
}
