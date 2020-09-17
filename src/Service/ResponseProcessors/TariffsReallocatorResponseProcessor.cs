namespace Linn.Products.Service.ResponseProcessors
{
    using Linn.Common.Facade;
    using Linn.Common.Nancy.Facade;
    using Linn.Products.Domain.Linnapps;

    public class TariffsReallocatorResponseProcessor : JsonResponseProcessor<ResponseModel<TariffsReallocator>>
    {
        public TariffsReallocatorResponseProcessor(IResourceBuilder<ResponseModel<TariffsReallocator>> resourceBuilder)
            : base(resourceBuilder, "tariffs-reallocator", 1)
        {
        }
    }
}
