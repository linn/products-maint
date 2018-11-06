namespace Linn.Products.Service.ResponseProcessors
{
    using System.Collections.Generic;

    using Linn.Common.Facade;
    using Linn.Common.Nancy.Facade;
    using Linn.Products.Domain.Linnapps;

    public class SernosConfigsResponseProcessor : JsonResponseProcessor<IEnumerable<SernosConfig>>
    {
        public SernosConfigsResponseProcessor(IResourceBuilder<IEnumerable<SernosConfig>> resourceBuilder)
            : base(resourceBuilder, "sernos-configs", 1)
        {
        }
    }
}