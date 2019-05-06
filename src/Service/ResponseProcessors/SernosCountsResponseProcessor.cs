namespace Linn.Products.Service.ResponseProcessors
{
    using System.Collections.Generic;

    using Linn.Common.Facade;
    using Linn.Common.Nancy.Facade;
    using Linn.Products.Domain.Linnapps.SernosTransactions;

    public class SernosCountsResponseProcessor : JsonResponseProcessor<IEnumerable<SernosCount>>
    {
        public SernosCountsResponseProcessor(IResourceBuilder<IEnumerable<SernosCount>> resourceBuilder)
            : base(resourceBuilder, "serial-number-counts", 1)
        {
        }
    }
}