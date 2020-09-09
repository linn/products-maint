namespace Linn.Products.Service.Extensions
{
    using Linn.Products.Domain.Products;
    using Linn.Products.Resources.MessageResources;
    using Linn.Products.Resources.ProductsResources;

    public static class ProductRangeExtensions
    {
        public static ProductRangeResource ToResource(this ProductRange productRange)
        {
            return new ProductRangeResource
            {
                createdBy = productRange.CreatedBy == null ? null : new LinkResource("created-by", productRange.CreatedBy),
                createdOn = productRange.CreatedOn,
                description = productRange.Description,
                id = productRange.Id,
                phasedOutBy = productRange.PhasedOutBy == null ? null : new LinkResource("phased-out-by", productRange.PhasedOutBy),
                phasedOutOn = productRange.PhasedOutOn,
                name = productRange.Name
            };
        }

        public static ProductRangeMessageResource ToMessageResource(this ProductRange productRange)
        {
            return new ProductRangeMessageResource()
            {
                createdBy = productRange.CreatedBy == null ? null : new LinkResource("created-by", productRange.CreatedBy),
                createdOn = productRange.CreatedOn,
                description = productRange.Description,
                id = productRange.Id.Value,
                phasedOutBy = productRange.PhasedOutBy == null ? null : new LinkResource("phased-out-by", productRange.PhasedOutBy),
                phasedOutOn = productRange.PhasedOutOn,
                name = productRange.Name
            };
        }
    }
}
