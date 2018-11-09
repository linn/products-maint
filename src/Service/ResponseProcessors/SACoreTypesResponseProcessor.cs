namespace Linn.Products.Service.ResponseProcessors
{
    using System.Collections.Generic;

    using Linn.Common.Facade;
    using Linn.Common.Nancy.Facade;
    using Linn.Products.Domain.Linnapps;

    public class SACoreTypesResponseProcessor : JsonResponseProcessor<IEnumerable<SACoreType>>
    {
        public SACoreTypesResponseProcessor(IResourceBuilder<IEnumerable<SACoreType>> resourceBuilder)
            : base(resourceBuilder, "sa-core-types", 1)
        {
        }
    }
}