namespace Linn.Products.Facade.Tests.ResourceBuilderSpecs.RootProductSpecs
{
    using System.Collections.Generic;

    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;

    using NUnit.Framework;

    public class WhenBuildingResourceWithPrivilegesOnHold : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            this.Privileges.Add("product.hold");
            this.Entity.HoldStories = new List<SaHoldStory> { new SaHoldStory() };
            this.Model = new ResponseModel<RootProduct>(this.Entity, this.Privileges);
            this.Result = this.Sut.Build(this.Model);
        }

        [Test]
        public void ShouldCreateResourceWithCorrectLinkRels()
        {
            this.Result.Name.Should().Be("RP");
            this.Result.Links.Should().HaveCount(2);
            this.Result.Links.Should().Contain(a => a.Rel == "self");
            this.Result.Links.Should().Contain(a => a.Rel == "put-off-hold");
            this.Result.Links.Should().NotContain(a => a.Rel == "put-on-hold");
        }
    }
}
