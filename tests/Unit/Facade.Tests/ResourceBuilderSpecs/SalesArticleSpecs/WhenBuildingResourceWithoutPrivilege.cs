namespace Linn.Products.Facade.Tests.ResourceBuilderSpecs.SalesArticleSpecs
{
    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps.Products;

    using NUnit.Framework;

    public class WhenBuildingResourceWithoutPrivileges : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            this.Model = new ResponseModel<SalesArticle>(this.Entity, this.Privileges);
            this.Result = this.Sut.Build(this.Model);
        }

        [Test]
        public void ShouldCreateResourceWithCorrectLinkRels()
        {
            this.Result.Links.Should().HaveCount(1);
            this.Result.Links.Should().Contain(a => a.Rel == "self");
        }
    }
}