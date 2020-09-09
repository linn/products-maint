namespace Linn.Products.Service.Extensions
{
    using System.Collections.Generic;
    using Linn.Common.Configuration;
    using Linn.Products.Domain.Products;
    using Linn.Products.Resources.MessageResources;
    using Linn.Products.Resources.ProductsResources;

    public static class RootProductExtensions
    {
        public static RootProductResource ToResource(this RootProduct rootProduct)
        {
            var resource = new RootProductResource
            {
                createdOn = rootProduct.CreatedOn,
                description = rootProduct.Description,
                hasSerialNumberOnBoard = rootProduct.HasSerialNumberOnBoard,
                id = rootProduct.Id,
                phasedOutOn = rootProduct.PhasedOutOn,
                name = rootProduct.Name
            };

            resource.links = new List<LinkResource>
                                 {
                                     new LinkResource
                                         {
                                             rel = "self",
                                             href = resource.href
                                         },
                                     new LinkResource
                                         {
                                             rel = "phase-in",
                                             href = resource.href + "/phase-in"
                                         },
                                     new LinkResource
                                         {
                                             rel = "phase-out",
                                             href = resource.href + "/phase-out"
                                         }
                                 };

            if (rootProduct.SalesProduct?.ProductRange != null)
            {
                var productRangeResource = rootProduct.SalesProduct.ProductRange.ToResource();
                resource.links.Add(new LinkResource { rel = "product-range", href = productRangeResource.href });
            }

            if (rootProduct.Carton != null)
            {
                var cartonResource = rootProduct.Carton.ToResource();
                resource.carton = cartonResource;
                resource.links.Add(new LinkResource { rel = "carton", href = cartonResource.href });
            }

            if (rootProduct.SalesProduct != null)
            {
                var salesProductResource = rootProduct.SalesProduct.ToResource();
                resource.salesProduct = salesProductResource;
                resource.links.Add(new LinkResource { rel = "sales-product", href = resource.salesProduct.href });
            }

            if (rootProduct.ProcommCategory != null)
            {
                var procommCategoryResource = rootProduct.ProcommCategory.ToResource();

                resource.procommCategory = procommCategoryResource;
                resource.links.Add(new LinkResource { rel = "product-category", href = resource.procommCategory.href });
            }

            if (rootProduct.CreatedBy != null)
            {
                var createdByResource = new LinkResource("created-by", rootProduct.CreatedBy.ToString());
                resource.createdBy = createdByResource;
                resource.links.Add(new LinkResource("created-by", createdByResource.href));
            }

            if (rootProduct.PhasedOutBy != null)
            {
                var phasedOutByResource = new LinkResource("phased-out-by", rootProduct.PhasedOutBy.ToString());
                resource.phasedOutBy = phasedOutByResource;
                resource.links.Add(new LinkResource { rel = "phased-out-by", href = phasedOutByResource.href });
            }

            return resource;
        }

        public static RootProductMessageResource ToMessageResource(this RootProduct rootProduct)
        {
            var resource = new RootProductMessageResource
            {
                createdOn = rootProduct.CreatedOn,
                description = rootProduct.Description,
                hasSerialNumberOnBoard = rootProduct.HasSerialNumberOnBoard,
                id = rootProduct.Id.Value,
                phasedOutOn = rootProduct.PhasedOutOn,
                name = rootProduct.Name
            };

            resource.links = new List<LinkResource>
                                 {
                                     new LinkResource
                                         {
                                             rel = "self",
                                             href = resource.href
                                         },
                                     new LinkResource
                                         {
                                             rel = "phase-in",
                                             href = resource.href + "/phase-in"
                                         },
                                     new LinkResource
                                         {
                                             rel = "phase-out",
                                             href = resource.href + "/phase-out"
                                         }
                                 };

            if (rootProduct.Carton != null)
            {
                var cartonResource = rootProduct.Carton.ToResource();
                resource.carton = cartonResource;
                resource.links.Add(new LinkResource { rel = "carton", href = cartonResource.href });
            }

            if (rootProduct.SalesProduct != null)
            {
                var salesProductResource = rootProduct.SalesProduct.ToMessageResource();
                resource.salesProduct = salesProductResource;
                resource.links.Add(new LinkResource { rel = "sales-product", href = resource.salesProduct.href });
                resource.productRange = salesProductResource.productRange;
            }

            if (rootProduct.ProcommCategory != null)
            {
                var procommCategoryResource = rootProduct.ProcommCategory.ToResource();

                resource.procommCategory = procommCategoryResource;
                resource.links.Add(new LinkResource { rel = "product-category", href = resource.procommCategory.href });
            }

            if (rootProduct.CreatedBy != null)
            {
                var createdByResource = new LinkResource("created-by", rootProduct.CreatedBy.ToString());
                resource.createdBy = createdByResource;
                resource.links.Add(new LinkResource("created-by", createdByResource.href));
            }

            if (rootProduct.PhasedOutBy != null)
            {
                var phasedOutByResource = new LinkResource("phased-out-by", rootProduct.PhasedOutBy.ToString());
                resource.phasedOutBy = phasedOutByResource;
                resource.links.Add(new LinkResource { rel = "phased-out-by", href = phasedOutByResource.href });
            }

            return resource;
        }
    }
}
