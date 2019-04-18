namespace Linn.Products.Facade.ResourceBuilders
{
    using System.Collections.Generic;
    using System.Linq;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    public class SernosTransactionsResourceBuilder : IResourceBuilder<IEnumerable<SernosTransaction>>
    {
        private readonly SernosTransactionResourceBuilder sernosTransactionResourceBuilder = new SernosTransactionResourceBuilder();

        public IEnumerable<SernosTransactionResource> Build(IEnumerable<SernosTransaction> sernosTransactions)
        {
            return sernosTransactions.Select(s => this.sernosTransactionResourceBuilder.Build(s));
        }

        public string GetLocation(IEnumerable<SernosTransaction> model)
        {
            throw new System.NotImplementedException();
        }

        object IResourceBuilder<IEnumerable<SernosTransaction>>.Build(IEnumerable<SernosTransaction> sernosTransactions) => this.Build(sernosTransactions);
    }
}
