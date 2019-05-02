namespace Linn.Products.Service.ResponseProcessors
{
    using Linn.Common.Facade;
    using Linn.Common.Nancy.Facade;
    using Linn.Products.Domain.Linnapps;

    public class RootProductResponseProcessor : JsonResponseProcessor<RootProduct>
    {
        public RootProductResponseProcessor(IResourceBuilder<RootProduct> resourceBuilder)
            : base(resourceBuilder, "root-product", 1)
        {
        }
    }
}