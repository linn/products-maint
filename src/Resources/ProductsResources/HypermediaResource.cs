namespace Linn.Products.Resources.ProductsResources
{
    using System.Collections.Generic;

    public abstract class HypermediaResource
    {
        public IList<LinkResource> links { get; set; }
    }
}
