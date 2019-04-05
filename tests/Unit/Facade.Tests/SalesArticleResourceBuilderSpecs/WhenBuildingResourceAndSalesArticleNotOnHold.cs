namespace Linn.Products.Facade.Tests.SalesArticleResourceBuilderSpecs
{
    using System.Linq;

    using FluentAssertions;

    using Linn.Products.Domain.Linnapps.Products;

    using NUnit.Framework;

    public class WhenBuildingResourceAndSalesArticleNotOnHold : ContextBase
    {
        private SalesArticle salesArticle;

        [SetUp]
        public void SetUp()
        {
            this.salesArticle = new SalesArticle { ArticleNumber = "sa", SaCoreType = null };
        }

        [Test]
        public void shouldBuildResource()
        {
            var resource = this.Sut.Build(this.salesArticle);
            resource.OnHold.Should().BeFalse();
        }
    }
}