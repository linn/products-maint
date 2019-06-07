namespace Linn.Products.Domain.Tests.AuthorisationServiceSpecs
{
    using FluentAssertions;

    using NUnit.Framework;

    public class WhenHasNoProductHoldPrivilege : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            this.Privileges.Add("something.unrelated");
            this.HasPrivilegeResult = this.Sut.HasPermissionFor("product.hold", this.Privileges);
        }

        [Test]
        public void ShouldReturnTrue()
        {
            this.HasPrivilegeResult.Should().BeFalse();
        }
    }
}
