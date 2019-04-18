namespace Linn.Products.Service.ResponseProcessors
{
    using System.Collections.Generic;

    using Linn.Common.Facade;
    using Linn.Common.Nancy.Facade;
    using Linn.Products.Domain.Linnapps;

    public class SernosTransactionsResponseProcessor : JsonResponseProcessor<IEnumerable<SernosTransaction>>
    {
        public SernosTransactionsResponseProcessor(IResourceBuilder<IEnumerable<SernosTransaction>> resourceBuilder)
            : base(resourceBuilder, "sernos-transes", 1)
        {
        }
    }
}
