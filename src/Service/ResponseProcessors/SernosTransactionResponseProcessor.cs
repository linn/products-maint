namespace Linn.Products.Service.ResponseProcessors
{
    using Linn.Common.Facade;
    using Linn.Common.Nancy.Facade;
    using Linn.Products.Domain.Linnapps;

    public class SernosTransactionResponseProcessor : JsonResponseProcessor<SernosTransaction>
    {
        public SernosTransactionResponseProcessor(IResourceBuilder<SernosTransaction> resourceBuilder)
            : base(resourceBuilder, "sernos-trans", 1)
        {
        }
    }
}
