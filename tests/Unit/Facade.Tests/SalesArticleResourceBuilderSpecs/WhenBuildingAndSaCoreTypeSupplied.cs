namespace Linn.Products.Facade.Tests.SalesArticleResourceBuilderSpecs
{
    using System.Linq;

    using FluentAssertions;

    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Domain.Linnapps.Products;

    using NUnit.Framework;

    public class WhenBuildingAndSaCoreTypeSupplied : ContextBase
    {
        private SalesArticle salesArticle;

        [SetUp]
        public void SetUp()
        {
            this.salesArticle = new SalesArticle { ArticleNumber = "sa", SaCoreType = new SaCoreType(1, "descr" )};
        }

        [Test]
        public void shouldBuildResourceWithoutLinkToCoreType()
        {
            var resource = this.Sut.Build(this.salesArticle);
            resource.Links.Any(l => l.Rel == "sa-core-type").Should().BeTrue();
        }
    }
}