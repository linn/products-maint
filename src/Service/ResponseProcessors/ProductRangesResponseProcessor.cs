namespace Linn.Products.Service.ResponseProcessors
{
    using System.Collections.Generic;

    using Linn.Common.Facade;
    using Linn.Common.Nancy.Facade;
    using Linn.Products.Domain.Linnapps.Products;

    public class ProductRangesResponseProcessor : JsonResponseProcessor<IEnumerable<ProductRange>>
    {
        public ProductRangesResponseProcessor(IResourceBuilder<IEnumerable<ProductRange>> resourceBuilder)
            : base(resourceBuilder, "product-ranges", 1)
        {
        }
    }
}