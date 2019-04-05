namespace Linn.Products.Facade.Tests.SalesArticleResourceBuilderSpecs
{
    using System.Collections.Generic;

    using FluentAssertions;

    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Domain.Linnapps.Products;

    using NUnit.Framework;

    public class WhenBuildingResourceAndSalesArticleOnHold : ContextBase
    {
        private SalesArticle salesArticle;

        [SetUp]
        public void SetUp()
        {
            this.salesArticle = new SalesArticle
                                    {
                                        ArticleNumber = "sa",
                                        HoldStories = new List<SaHoldStory> { new SaHoldStory { DateFinished = null } }
                                    };
        }

        [Test]
        public void ShouldBuildResourceWithOnHoldTrue()
        {
            var resource = this.Sut.Build(this.salesArticle);
            resource.OnHold.Should().BeTrue();
        }
    }
}