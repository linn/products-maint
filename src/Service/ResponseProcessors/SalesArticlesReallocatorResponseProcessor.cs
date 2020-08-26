namespace Linn.Products.Service.ResponseProcessors
{
    using Linn.Common.Facade;
    using Linn.Common.Nancy.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Domain.Linnapps.Products;

    public class SalesArticlesReallocatorResponseProcessor : JsonResponseProcessor<ResponseModel<SalesArticlesReallocator>>
    {
        public SalesArticlesReallocatorResponseProcessor(IResourceBuilder<ResponseModel<SalesArticlesReallocator>> resourceBuilder)
            : base(resourceBuilder, "sales-articles-reallocator", 1)
        {
        }
    }
}