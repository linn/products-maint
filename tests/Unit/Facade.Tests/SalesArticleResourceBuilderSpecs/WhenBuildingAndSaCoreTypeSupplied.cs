namespace Linn.Products.Facade.Tests.SalesArticleResourceBuilderSpecs
{
    using System.Linq;

    using FluentAssertions;

    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Resources;

    using NUnit.Framework;

    public class WhenBuildingAndSaCoreTypeSupplied : ContextBase
    {
        private SalesArticle salesArticle;

        private SalesArticleResource resource;

        [SetUp]
        public void SetUp()
        {
            this.salesArticle = new SalesArticle { ArticleNumber = "sa", SaCoreType = new SaCoreType(1, "descr") };
            this.resource = this.Sut.Build(this.salesArticle);
        }

        [Test]
        public void ShouldBuildResourceWithLinkToCoreType()
        {
            this.resource.Links.Any(l => l.Rel == "sa-core-type").Should().BeTrue();
        }
    }
}