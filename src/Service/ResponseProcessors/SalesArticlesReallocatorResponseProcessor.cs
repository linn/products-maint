namespace Linn.Products.Service.ResponseProcessors
{
    using Linn.Common.Facade;
    using Linn.Common.Nancy.Facade;
    using Linn.Products.Domain.Linnapps;

    public class SalesArticlesReallocatorResponseProcessor : JsonResponseProcessor<ResponseModel<TariffsReallocator>>
    {
        public SalesArticlesReallocatorResponseProcessor(IResourceBuilder<ResponseModel<TariffsReallocator>> resourceBuilder)
            : base(resourceBuilder, "sales-articles-reallocator", 1)
        {
        }
    }
}
