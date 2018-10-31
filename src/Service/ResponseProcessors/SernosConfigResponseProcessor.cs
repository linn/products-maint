namespace Linn.Products.Service.ResponseProcessors
{
    using Linn.Common.Facade;
    using Linn.Common.Nancy.Facade;
    using Linn.Products.Domain.Linnapps;

    public class SernosConfigResponseProcessor : JsonResponseProcessor<SernosConfig>
    {
        public SernosConfigResponseProcessor(IResourceBuilder<SernosConfig> resourceBuilder)
            : base(resourceBuilder, "sernos-config", 1)
        {
        }
    }
}