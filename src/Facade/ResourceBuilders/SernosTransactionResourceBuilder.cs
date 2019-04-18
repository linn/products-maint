namespace Linn.Products.Facade.ResourceBuilders
{
    using System.Collections.Generic;
    using System.Linq;

    using Linn.Common.Facade;
    using Linn.Common.Resources;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    public class SernosTransactionResourceBuilder : IResourceBuilder<SernosTransaction>
    {
        public SernosTransactionResource Build(SernosTransaction sernosTransaction)
        {
            return new SernosTransactionResource
                       {
                           TransCode = sernosTransaction.TransCode,
                           TransDescription = sernosTransaction.TransDescription,
                           Comments = sernosTransaction.Comments,
                           Links = this.BuildLinks(sernosTransaction).ToArray()
                       };
        }

        public string GetLocation(SernosTransaction sernosTransaction)
        {
            return $"/products/maint/sernos-transactions/{sernosTransaction.TransCode}";
        }

        object IResourceBuilder<SernosTransaction>.Build(SernosTransaction sernosTransaction) => this.Build(sernosTransaction);

        private IEnumerable<LinkResource> BuildLinks(SernosTransaction sernosTransaction)
        {
            yield return new LinkResource { Rel = "self", Href = this.GetLocation(sernosTransaction) };
        }
    }
}
