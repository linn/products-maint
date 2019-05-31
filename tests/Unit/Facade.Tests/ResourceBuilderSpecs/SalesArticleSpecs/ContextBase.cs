namespace Linn.Products.Facade.Tests.ResourceBuilderSpecs.SalesArticleSpecs
{
    using System.Collections.Generic;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Facade.ResourceBuilders;
    using Linn.Products.Resources;

    using NUnit.Framework;

    public abstract class ContextBase
    {
        protected SalesArticleResource Result { get; set; }

        protected SalesArticleResourceBuilder Sut { get; private set; }

        protected ResponseModel<SalesArticle> Model { get; set; }

        protected SalesArticle Entity { get; set; }

        protected List<string> Privileges { get; set; }

        [SetUp]
        public void SetUpContext()
        {
            this.Sut = new SalesArticleResourceBuilder();
            this.Entity = new SalesArticle { ArticleNumber = "AR" };
            this.Privileges = new List<string>();
        }

    }
}
