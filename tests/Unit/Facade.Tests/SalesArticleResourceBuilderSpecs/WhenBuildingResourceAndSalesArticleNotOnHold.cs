namespace Linn.Products.Facade.Tests.SalesArticleResourceBuilderSpecs
{
    using System.Linq;

    using FluentAssertions;

    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Resources;

    using NUnit.Framework;

    public class WhenBuildingResourceAndSalesArticleNotOnHold : ContextBase
    {
        private SalesArticle salesArticle;

        private SalesArticleResource resource;
             
        [SetUp]
        public void SetUp()
        {
            this.salesArticle = new SalesArticle { ArticleNumber = "sa", SaCoreType = null };
            this.resource = this.Sut.Build(this.salesArticle);
        }

        [Test]
        public void ShouldBuildResourceWithOnHoldFalse()
        {
            this.resource.OnHold.Should().BeFalse();
        }
    }
}