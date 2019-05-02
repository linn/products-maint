namespace Linn.Products.Service.ResponseProcessors
{
    using System.Collections.Generic;

    using Linn.Common.Facade;
    using Linn.Common.Nancy.Facade;
    using Linn.Products.Domain.Linnapps;

    public class RootProductsResponseProcessor : JsonResponseProcessor<IEnumerable<RootProduct>>
    {
        public RootProductsResponseProcessor(IResourceBuilder<IEnumerable<RootProduct>> resourceBuilder)
            : base(resourceBuilder, "root-products", 1)
        {
        }
    }
}