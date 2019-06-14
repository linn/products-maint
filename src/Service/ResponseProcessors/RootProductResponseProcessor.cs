namespace Linn.Products.Service.ResponseProcessors
{
    using Linn.Common.Facade;
    using Linn.Common.Nancy.Facade;
    using Linn.Products.Domain.Linnapps.Products;

    public class RootProductResponseProcessor : JsonResponseProcessor<ResponseModel<RootProduct>>
    {
        public RootProductResponseProcessor(IResourceBuilder<ResponseModel<RootProduct>> resourceBuilder)
            : base(resourceBuilder, "root-product", 1)
        {
        }
    }
}