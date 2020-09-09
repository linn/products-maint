// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VatCodeExtensions.cs" company="Linn Products Ltd.">
//   Copyright © 2013 Linn Products Limited. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Linn.Products.Service.Extensions
{
    using Linn.Products.Domain.Products;
    using Linn.Products.Resources.ProductsResources;

    public static class VatCodeExtensions
    {
        public static VatCodeResource ToResource(this VatCode vatCode)
        {
            var resource = new VatCodeResource()
            {
                id = vatCode.Id,
                vatDescription = vatCode.VatDescription,
                vatRate = vatCode.VatRate,
                isVatOnly = vatCode.IsVatOnly,
                linnAppsKey = vatCode.LinnAppsKey
            };
            return resource;
        }
    }
}
