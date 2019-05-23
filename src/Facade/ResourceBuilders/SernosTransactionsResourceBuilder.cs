namespace Linn.Products.Facade.ResourceBuilders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps.SernosTransactions;
    using Linn.Products.Resources;

    public class SernosTransactionsResourceBuilder : IResourceBuilder<IEnumerable<SernosTrans>>
    {
        private readonly SernosTransactionResourceBuilder sernosTransResourceBuilder = new SernosTransactionResourceBuilder();

        public IEnumerable<SernosTransactionResource> Build(IEnumerable<SernosTrans> sernosTransactions)
        {
            return sernosTransactions.Select(a => this.sernosTransResourceBuilder.Build(a));
        }

        object IResourceBuilder<IEnumerable<SernosTrans>>.Build(IEnumerable<SernosTrans> sernosTransactions) => this.Build(sernosTransactions);

        public string GetLocation(IEnumerable<SernosTrans> sernosTransactions)
        {
            throw new NotImplementedException();
        }
    }
}
