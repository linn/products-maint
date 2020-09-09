// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TypeOfSaleExtensions.cs" company="Linn Products Ltd.">
//   Copyright © 2013 Linn Products Limited. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Linn.Products.Service.Extensions
{
    using Linn.Products.Domain.Products;
    using Linn.Products.Resources.ProductsResources;

    public static class TypeOfSaleExtensions
    {
        public static TypeOfSaleResource ToResource(this TypeOfSale typeOfSale)
        {
            var resource = new TypeOfSaleResource
            {
                createdBy = typeOfSale.CreatedBy == null ? null : new LinkResource("created-by", typeOfSale.CreatedBy),
                createdOn = typeOfSale.CreatedOn,
                description = typeOfSale.Description,
                phasedOutBy = typeOfSale.PhasedOutBy == null ? null : new LinkResource("phased-out-by", typeOfSale.PhasedOutBy),
                id = typeOfSale.Id,
                phasedOutOn = typeOfSale.PhasedOutOn,
                name = typeOfSale.Name
            };
            return resource;
        }
    }
}
