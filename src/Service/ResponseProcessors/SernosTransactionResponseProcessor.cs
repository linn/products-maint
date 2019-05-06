namespace Linn.Products.Service.ResponseProcessors
{
    using Linn.Common.Facade;
    using Linn.Common.Nancy.Facade;
    using Linn.Products.Domain.Linnapps.SernosTransactions;

    public class SernosTransactionResponseProcessor : JsonResponseProcessor<SernosTrans>
    {
        public SernosTransactionResponseProcessor(IResourceBuilder<SernosTrans> resourceBuilder)
            : base(resourceBuilder, "serial-number-transaction", 1)
        {
        }
    }
}
