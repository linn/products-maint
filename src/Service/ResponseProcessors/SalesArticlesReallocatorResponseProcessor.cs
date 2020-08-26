namespace Linn.Products.Service.ResponseProcessors
{
    using Linn.Common.Facade;
    using Linn.Common.Nancy.Facade;
    using Linn.Products.Domain.Linnapps;

    public class SalesArticlesReallocatorResponseProcessor : JsonResponseProcessor<SalesArticlesReallocator>
    {
        public SalesArticlesReallocatorResponseProcessor(IResourceBuilder<SalesArticlesReallocator> resourceBuilder)
            : base(resourceBuilder, "sales-articles-reallocator", 1)
        {
        }
    }
}