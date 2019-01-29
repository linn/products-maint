namespace Linn.Products.Service.ResponseProcessors
{
    using Linn.Common.Facade;
    using Linn.Common.Nancy.Facade;
    using Linn.Products.Domain.Linnapps.Products;

    public class SalesArticleResponseProcessor : JsonResponseProcessor<SalesArticle>
    {
        public SalesArticleResponseProcessor(IResourceBuilder<SalesArticle> resourceBuilder)
            : base(resourceBuilder, "sales-article", 1)
        {
        }
    }
}