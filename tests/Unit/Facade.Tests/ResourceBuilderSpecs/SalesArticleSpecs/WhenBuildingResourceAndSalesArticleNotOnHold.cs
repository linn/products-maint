﻿namespace Linn.Products.Facade.Tests.ResourceBuilderSpecs.SalesArticleSpecs
{
    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Resources;

    using NUnit.Framework;

    public class WhenBuildingResourceAndSalesArticleNotOnHold : ContextBase
    {
        private ResponseModel<SalesArticle> salesArticle;

        private SalesArticleResource resource;
             
        [SetUp]
        public void SetUp()
        {
            this.salesArticle = new ResponseModel<SalesArticle>( new SalesArticle { ArticleNumber = "sa", SaCoreType = null }, null);
            this.resource = this.Sut.Build(this.salesArticle);
        }

        [Test]
        public void ShouldBuildResourceWithOnHoldFalse()
        {
            this.resource.OnHold.Should().BeFalse();
        }
    }
}