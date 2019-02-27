namespace Linn.Products.Domain.Linnapps.Tests.SalesArticleSpecs
{
    using Linn.Products.Domain.Linnapps.Products;

    using NUnit.Framework;

    public abstract class ContextBase
    {
        protected SalesArticle Sut { get; private set; }

        [SetUp]
        public void SetUpContext()
        {
            this.Sut = new SalesArticle
                           {
                               ArticleNumber = "Article",
                               InvoiceDescription = "Description"
                           };
        }
    }
}
