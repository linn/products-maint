// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProcommCategoryExtensions.cs" company="Linn Products Ltd.">
//   Copyright © 2012 Linn Products Limited. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Linn.Products.Service.Extensions
{
    using Linn.Products.Domain.Products;
    using Linn.Products.Resources.ProductsResources;

    public static class ProcommCategoryExtensions
    {
        public static ProcommCategoryResource ToResource(this ProcommCategory procommCategory)
        {
            return new ProcommCategoryResource
            {
                description = procommCategory.Description,
                phasedOutBy = procommCategory.PhasedOutBy == null ? null : new LinkResource("phased-out-by", procommCategory.PhasedOutBy),
                id = procommCategory.Id,
                phasedOutOn = procommCategory.PhasedOutOn
            };
        }
    }
}
