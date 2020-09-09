// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TypeOfSerialNumberExtensions.cs" company="Linn Products Ltd.">
//   Copyright © 2013 Linn Products Limited. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Linn.Products.Service.Extensions
{
    using Linn.Products.Domain.Products;
    using Linn.Products.Resources.ProductsResources;

    public static class TypeOfSerialNumberExtensions
    {
        public static TypeOfSerialNumberResource ToResource(this TypeOfSerialNumber typeOfSerialNumber)
        {
            var resource = new TypeOfSerialNumberResource
            {
                id = typeOfSerialNumber.Id,
                name = typeOfSerialNumber.Name,
                description = typeOfSerialNumber.Description,
                numberOfBoxes = typeOfSerialNumber.NumberOfBoxes,
                numberOfSerialNumbers = typeOfSerialNumber.NumberOfSerialNumbers
            };
            return resource;
        }
    }
}
