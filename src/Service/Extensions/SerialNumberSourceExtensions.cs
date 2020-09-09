// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SerialNumberSourceExtensions.cs" company="Linn Products Ltd.">
//   Copyright © 2013 Linn Products Limited. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Linn.Products.Service.Extensions
{
    using Linn.Products.Domain.Products;
    using Linn.Products.Resources.ProductsResources;

    public static class SerialNumberSourceExtensions
    {
        public static SerialNumberSourceResource ToResource(this SerialNumberSource serialNumberSource)
        {
            var resource = new SerialNumberSourceResource();
            resource.id = serialNumberSource.Id;
            resource.createdOn = serialNumberSource.CreatedOn;
            resource.createdBy = serialNumberSource.CreatedBy == null ? null : new LinkResource("created-by", serialNumberSource.CreatedBy);
            resource.phasedOutOn = serialNumberSource.PhasedOutOn;
            resource.phasedOutBy = serialNumberSource.PhasedOutBy == null ? null : new LinkResource("phased-out-by", serialNumberSource.PhasedOutBy);
            resource.name = serialNumberSource.Name;
            resource.description = serialNumberSource.Description;
            return resource;
        }
    }
}
