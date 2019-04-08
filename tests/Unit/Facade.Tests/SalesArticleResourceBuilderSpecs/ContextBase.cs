namespace Linn.Products.Facade.Tests.SalesArticleResourceBuilderSpecs
{
    using Linn.Products.Facade.ResourceBuilders;

    using NUnit.Framework;

    public abstract class ContextBase
    {
        protected SalesArticleResourceBuilder Sut { get; private set; }

        [SetUp]
        public void SetUpContext()
        {
            this.Sut = new SalesArticleResourceBuilder();
        }
    }
}
