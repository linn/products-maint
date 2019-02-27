namespace Linn.Products.Facade.ResourceBuilders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Resources;

    public class ProductRangesResourceBuilder : IResourceBuilder<IEnumerable<ProductRange>>
    {
        private readonly ProductRangeResourceBuilder productRangeResourceBuilder = new ProductRangeResourceBuilder();

        public IEnumerable<ProductRangeResource> Build(IEnumerable<ProductRange> productRanges)
        {
            return productRanges.Select(a => this.productRangeResourceBuilder.Build(a));
        }

        object IResourceBuilder<IEnumerable<ProductRange>>.Build(IEnumerable<ProductRange> productRanges) =>
            this.Build(productRanges);

        public string GetLocation(IEnumerable<ProductRange> productRanges)
        {
            throw new NotImplementedException();
        }
    }
}