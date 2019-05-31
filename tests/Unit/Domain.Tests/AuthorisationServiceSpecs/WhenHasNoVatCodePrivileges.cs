namespace Linn.Products.Domain.Tests.AuthorisationServiceSpecs
{
    using FluentAssertions;

    using NUnit.Framework;

    public class WhenHasNoVatCodePrivileges : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            this.HasPrivilegeResult = this.Sut.CanEditOrCreateVatCodes(this.Privileges);
        }

        [Test]
        public void ShouldReturnFalse()
        {
            this.HasPrivilegeResult.Should().BeFalse();
        }
    }
}
