namespace Linn.Products.Service.ResponseProcessors
{
    using System.Collections.Generic;

    using Linn.Common.Facade;
    using Linn.Common.Nancy.Facade;
    using Linn.Products.Domain.Linnapps;

    public class SernosTransesResponseProcessor : JsonResponseProcessor<IEnumerable<SernosTrans>>
    {
        public SernosTransesResponseProcessor(IResourceBuilder<IEnumerable<SernosTrans>> resourceBuilder)
            : base(resourceBuilder, "sernos-transes", 1)
        {
        }
    }
}
