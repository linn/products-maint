namespace Linn.Products.Service.ResponseProcessors
{
    using System.Collections.Generic;

    using Linn.Common.Facade;
    using Linn.Common.Nancy.Facade;
    using Linn.Products.Domain.Linnapps.SernosTransactions;

    public class SernosTransactionsResponseProcessor : JsonResponseProcessor<IEnumerable<SernosTrans>>
    {
        public SernosTransactionsResponseProcessor(IResourceBuilder<IEnumerable<SernosTrans>> resourceBuilder)
            : base(resourceBuilder, "serial-number-transactions", 1)
        {
        }
    }
}