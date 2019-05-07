namespace Linn.Products.Service.ResponseProcessors
{
    using Linn.Common.Facade;
    using Linn.Common.Nancy.Facade;
    using Linn.Products.Domain.Linnapps.SernosTransactions;

    using PagedList.Core;

    public class SernosTransactionsPaginatedResponseProcessor : JsonResponseProcessor<IPagedList<SernosTrans>>
    {
        public SernosTransactionsPaginatedResponseProcessor(IResourceBuilder<IPagedList<SernosTrans>> resourceBuilder)
            : base(resourceBuilder, "serial-number-transactions", 1)
        {
        }
    }
}
