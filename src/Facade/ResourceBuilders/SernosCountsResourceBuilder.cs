namespace Linn.Products.Facade.ResourceBuilders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps.SernosTransactions;
    using Linn.Products.Resources;

    public class SernosCountsResourceBuilder : IResourceBuilder<IEnumerable<SernosCount>>
    {
        private readonly SernosCountResourceBuilder sernosCountResourceBuilder = new SernosCountResourceBuilder();

        public IEnumerable<SernosCountResource> Build(IEnumerable<SernosCount> sernosCounts)
        {
            return sernosCounts.Select(a => this.sernosCountResourceBuilder.Build(a));
        }

        object IResourceBuilder<IEnumerable<SernosCount>>.Build(IEnumerable<SernosCount> sernosCounts) => this.Build(sernosCounts);

        public string GetLocation(IEnumerable<SernosCount> sernosCounts)
        {
            throw new NotImplementedException();
        }
    }
}