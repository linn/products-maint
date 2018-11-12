namespace Linn.Products.Service.ResponseProcessors
{
    using System.Collections.Generic;

    using Linn.Common.Facade;
    using Linn.Common.Nancy.Facade;
    using Linn.Products.Domain.Linnapps;

    public class SaCoreTypesResponseProcessor : JsonResponseProcessor<IEnumerable<SaCoreType>>
    {
        public SaCoreTypesResponseProcessor(IResourceBuilder<IEnumerable<SaCoreType>> resourceBuilder)
            : base(resourceBuilder, "sa-core-types", 1)
        {
        }
    }
}