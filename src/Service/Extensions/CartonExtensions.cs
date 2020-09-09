// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CartonExtensions.cs" company="Linn Products Ltd.">
//   Copyright © 2012 Linn Products Limited. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Linn.Products.Service.Extensions
{
    using Linn.Products.Domain.Products;
    using Linn.Products.Resources.ProductsResources;

    public static class CartonExtensions
    {
        public static CartonResource ToResource(this Carton carton)
        {
            return new CartonResource
                {
                    depth = carton.Depth, 
                    height = carton.Height, 
                    id = carton.Id, 
                    name = carton.Name,
                    description = carton.Description,
                    volume = carton.Volume, 
                    width = carton.Width
                };
        }
    }
}
