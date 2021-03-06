﻿namespace Linn.Products.Facade.Tests.ResourceBuilderSpecs.SalesArticleSpecs
{
    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Domain.Linnapps.Products;

    using NUnit.Framework;

    public class WhenBuildingResourceWithPrivilegesAndNotOnHold : ContextBase
    {
        [SetUp]
        public void SetUp()
        {
            this.Privileges.Add("product.hold");
            this.Model = new ResponseModel<SalesArticle>(this.Entity, this.Privileges);
            this.Result = this.Sut.Build(this.Model);
        }

        [Test]
        public void ShouldCreateResourceWithCorrectLinkRels()
        {
            this.Result.ArticleNumber.Should().Be("AR");
            this.Result.Links.Should().HaveCount(2);
            this.Result.Links.Should().Contain(a => a.Rel == "self");
            this.Result.Links.Should().Contain(a => a.Rel == "put-on-hold");
            this.Result.Links.Should().NotContain(a => a.Rel == "put-off-hold");
        }
    }
}
