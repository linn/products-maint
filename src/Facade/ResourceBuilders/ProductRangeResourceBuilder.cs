namespace Linn.Products.Facade.ResourceBuilders
{
    using System.Collections.Generic;
    using System.Linq;

    using Linn.Common.Facade;
    using Linn.Common.Resources;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Resources;

    public class ProductRangeResourceBuilder : IResourceBuilder<ProductRange>
    {
        public ProductRangeResource Build(ProductRange productRange)
        {
            return new ProductRangeResource
                       {
                           Id = productRange.Id,
                           RangeName = productRange.RangeName,
                           RangeDescription  = productRange.RangeDescription,
                           DateInvalid = productRange.DateInvalid?.ToString("o"),
                           Links = this.BuildLinks(productRange).ToArray()
                       };
        }

        object IResourceBuilder<ProductRange>.Build(ProductRange productRange) => this.Build(productRange);

        public string GetLocation(ProductRange productRange)
        {
            return $"/products/maint/product-ranges/{productRange.Id}";
        }

        private IEnumerable<LinkResource> BuildLinks(ProductRange productRange)
        {
            yield return new LinkResource
                             {
                                 Rel = "self",
                                 Href = this.GetLocation(productRange)
                             };
        }
    }
}