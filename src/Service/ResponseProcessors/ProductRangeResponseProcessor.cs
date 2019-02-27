namespace Linn.Products.Service.ResponseProcessors
{
    using Linn.Common.Facade;
    using Linn.Common.Nancy.Facade;
    using Linn.Products.Domain.Linnapps.Products;

    public class ProductRangeResponseProcessor : JsonResponseProcessor<ProductRange>
    {
        public ProductRangeResponseProcessor(IResourceBuilder<ProductRange> resourceBuilder)
            : base(resourceBuilder, "product-range", 1)
        {
        }
    }
}