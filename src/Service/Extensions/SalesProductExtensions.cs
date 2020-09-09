namespace Linn.Products.Service.Extensions
{
    using System.Collections.Generic;
    using Linn.Products.Domain.Products;
    using Linn.Products.Resources.MessageResources;
    using Linn.Products.Resources.ProductsResources;

    public static class SalesProductExtensions
    {
        public static SalesProductResource ToResource(this SalesProduct salesProduct)
        {
            var resource = new SalesProductResource
            {
                createdOn = salesProduct.CreatedOn.ToString("o"),
                id = salesProduct.Id,
                name = salesProduct.Name,
                description = salesProduct.Description,
                displayOnTradeSite = salesProduct.DisplayOnTradeSite
            };
            if (salesProduct.PhasedOutOn != null)
            {
                resource.phasedOutOn = salesProduct.PhasedOutOn.Value.ToString("o");
            }

            if (salesProduct.PhasedInOn != null)
            {
                resource.phasedInOn = salesProduct.PhasedInOn.Value.ToString("o");
            }

            resource.links = new List<LinkResource>
                                 {
                                     new LinkResource
                                         {
                                             rel = "self",
                                             href = resource.href
                                         }
                                 };

            if (salesProduct.ProductRange != null)
            {
                var productRangeResource = salesProduct.ProductRange.ToResource();
                resource.productRange = productRangeResource;
                resource.links.Add(new LinkResource { rel = "product-range", href = productRangeResource.href });
            }

            if (salesProduct.CreatedBy != null)
            {
                var createdByResource = new LinkResource("created-by", salesProduct.CreatedBy.ToString());
                resource.links.Add(new LinkResource("created-by", createdByResource.href));
            }

            if (salesProduct.PhasedOutBy != null)
            {
                var phasedOutByResource = new LinkResource("phased-out-by", salesProduct.PhasedOutBy.ToString());
                resource.links.Add(new LinkResource { rel = "phased-out-by", href = phasedOutByResource.href });
            }

            return resource;
        }

        public static SalesProductMessageResource ToMessageResource(this SalesProduct salesProduct)
        {
            var resource = new SalesProductMessageResource
            {
                createdOn = salesProduct.CreatedOn.ToString("o"),
                id = salesProduct.Id.Value,
                name = salesProduct.Name,
                description = salesProduct.Description
            };
            if (salesProduct.PhasedOutOn != null)
            {
                resource.phasedOutOn = salesProduct.PhasedOutOn.Value.ToString("o");
            }

            if (salesProduct.PhasedInOn != null)
            {
                resource.phasedInOn = salesProduct.PhasedInOn.Value.ToString("o");
            }

            resource.links = new List<LinkResource>
                                 {
                                     new LinkResource
                                         {
                                             rel = "self",
                                             href = resource.href
                                         }
                                 };

            if (salesProduct.ProductRange != null)
            {
                var productRangeResource = salesProduct.ProductRange.ToMessageResource();
                resource.productRange = productRangeResource;
                resource.links.Add(new LinkResource { rel = "product-range", href = resource.productRange.href });
            }

            if (salesProduct.CreatedBy != null)
            {
                var createdByResource = new LinkResource("created-by", salesProduct.CreatedBy.ToString());
                resource.links.Add(new LinkResource("created-by", createdByResource.href));
            }

            if (salesProduct.PhasedOutBy != null)
            {
                var phasedOutByResource = new LinkResource("phased-out-by", salesProduct.PhasedOutBy.ToString());
                resource.links.Add(new LinkResource { rel = "phased-out-by", href = phasedOutByResource.href });
            }

            return resource;
        }
    }
}