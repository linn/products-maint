namespace Linn.Products.Domain.Tests.AuthorisationServiceSpecs
{
    using FluentAssertions;

    using NUnit.Framework;

    public class WhenHasProductHoldPrivilege : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            this.Privileges.Add("product.hold");
            this.HasPrivilegeResult = this.Sut.HasPermissionFor("product.hold", this.Privileges);
        }

        [Test]
        public void ShouldReturnTrue()
        {
            this.HasPrivilegeResult.Should().BeTrue();
        }
    }
}
