namespace Linn.Products.Facade.Tests.SalesArticleResourceBuilderSpecs
{
    using System.Linq;

    using FluentAssertions;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Resources;

    using NUnit.Framework;

    public class WhenBuildingAndSaCoreTypeSupplied : ContextBase
    {
        private ResponseModel<SalesArticle> salesArticle;

        private SalesArticleResource resource;

        [SetUp]
        public void SetUp()
        {
            this.salesArticle = new ResponseModel<SalesArticle>(
                new SalesArticle { ArticleNumber = "sa", SaCoreType = new SaCoreType(1, "descr") }, null);
            this.resource = this.Sut.Build(this.salesArticle);
        }

        [Test]
        public void ShouldBuildResourceWithLinkToCoreType()
        {
            this.resource.Links.Any(l => l.Rel == "sa-core-type").Should().BeTrue();
        }
    }
}