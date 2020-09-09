// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TariffExtensions.cs" company="Linn Products Ltd.">
//   Copyright © 2013 Linn Products Limited. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Linn.Products.Service.Extensions
{
    using Linn.Products.Domain.Products;
    using Linn.Products.Resources.ProductsResources;

    public static class TariffExtensions
    {
        public static ProductsTariffResource ToResource(this Tariff tariff)
        {
            var resource = new ProductsTariffResource()
            {
                id = tariff.Id,
                description = tariff.Description,
                ukTariffCode = tariff.UkTariffCode,
                usTariffCode = tariff.UsTariffCode
            };
            return resource;
        }
    }
}
