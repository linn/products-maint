﻿namespace Linn.Products.Facade.Tests.SalesArticleResourceBuilderSpecs
{
    using System.Collections.Generic;

    using FluentAssertions;

    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Resources;

    using NUnit.Framework;

    public class WhenBuildingResourceAndSalesArticleOnHold : ContextBase
    {
        private SalesArticle salesArticle;

        private SalesArticleResource resource;

        [SetUp]
        public void SetUp()
        {
            this.salesArticle = new SalesArticle
                                    {
                                        ArticleNumber = "sa",
                                        HoldStories = new List<SaHoldStory> { new SaHoldStory { DateFinished = null } }
                                    };

            this.resource = this.Sut.Build(this.salesArticle);
        }

        [Test]
        public void ShouldBuildResourceWithOnHoldTrue()
        { 
            this.resource.OnHold.Should().BeTrue();
        }
    }
}