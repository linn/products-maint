namespace Linn.Products.Facade.Tests.ResourceBuilderSpecs.VatCodeSpecs
{
    using FluentAssertions;

    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Facade.Models;

    using NUnit.Framework;

    public class WhenBuildingResourceWithPrivileges : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            this.Privileges.Add("finance.admin");
            this.Model = new ResponseModel<VatCode>(this.Entity, this.Privileges);
            this.Result = this.Sut.Build(this.Model);
        }

        [Test]
        public void ShouldCreateResourceWithCorrectLinkRels()
        {
            this.Result.Code.Should().Be("a");
            this.Result.Links.Should().HaveCount(2);
            this.Result.Links.Should().Contain(a => a.Rel == "self");
            this.Result.Links.Should().Contain(a => a.Rel == "edit");
        }
    }
}
