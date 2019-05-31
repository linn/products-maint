namespace Linn.Products.Service.ResponseProcessors
{
    using Linn.Common.Facade;
    using Linn.Common.Nancy.Facade;
    using Linn.Products.Domain.Linnapps.Products;

    public class SalesArticleResponseProcessor : JsonResponseProcessor<ResponseModel<SalesArticle>>
    {
        public SalesArticleResponseProcessor(IResourceBuilder<ResponseModel<SalesArticle>> resourceBuilder)
            : base(resourceBuilder, "sales-article", 1)
        {
        }
    }
}