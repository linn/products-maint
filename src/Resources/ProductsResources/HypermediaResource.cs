namespace Linn.Products.Resources.ProductsResources
{
    using System.Collections.Generic;

    using Linn.Common.Resources;

    public abstract class HypermediaResource
    {
        public IList<LinkResource> links { get; set; }
    }
}