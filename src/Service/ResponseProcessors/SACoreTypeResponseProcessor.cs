namespace Linn.Products.Service.ResponseProcessors
{
    using System.Collections.Generic;

    using Linn.Common.Facade;
    using Linn.Common.Nancy.Facade;
    using Linn.Products.Domain.Linnapps;

    public class SACoreTypeResponseProcessor : JsonResponseProcessor<SACoreType>
    {
        public SACoreTypeResponseProcessor(IResourceBuilder<SACoreType> resourceBuilder)
            : base(resourceBuilder, "sa-core-types", 1)
        {
        }
    }
}