namespace Linn.Products.Service.ResponseProcessors
{
    using Linn.Common.Facade;
    using Linn.Common.Nancy.Facade;
    using Linn.Products.Domain.Linnapps;

    public class SaCoreTypeResponseProcessor : JsonResponseProcessor<SaCoreType>
    {
        public SaCoreTypeResponseProcessor(IResourceBuilder<SaCoreType> resourceBuilder)
            : base(resourceBuilder, "sa-core-type", 1)
        {
        }
    }
}