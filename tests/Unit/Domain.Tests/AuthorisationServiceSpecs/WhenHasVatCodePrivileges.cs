namespace Linn.Products.Domain.Tests.AuthorisationServiceSpecs
{
    using FluentAssertions;

    using NUnit.Framework;

    public class WhenHasVatCodePrivileges : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            this.Privileges.Add("vat.admin");
            this.HasPrivilegeResult = this.Sut.HasPermissionFor(AuthorisedAction.VatAdmin, this.Privileges);
        }

        [Test]
        public void ShouldReturnTrue()
        {
            this.HasPrivilegeResult.Should().BeTrue();
        }
    }
}
