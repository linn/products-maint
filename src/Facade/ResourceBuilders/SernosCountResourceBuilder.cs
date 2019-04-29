namespace Linn.Products.Facade.ResourceBuilders
{
    using System.Collections.Generic;
    using System.Linq;

    using Linn.Common.Facade;
    using Linn.Common.Resources;
    using Linn.Products.Domain.Linnapps.SernosTransactions;
    using Linn.Products.Resources;

    public class SernosCountResourceBuilder : IResourceBuilder<SernosCount>
    {
        public SernosCountResource Build(SernosCount sernosCount)
        {
            return new SernosCountResource
            {
                           Name = sernosCount.Name,
                           Description = sernosCount.Description,
                           Links = this.BuildLinks(sernosCount).ToArray()
                       };
        }

        object IResourceBuilder<SernosCount>.Build(SernosCount sernosCount) => this.Build(sernosCount);

        public string GetLocation(SernosCount sernosCount)
        {
            return $"/products/maint/serial-number-counts/{sernosCount.Name}";
        }

        private IEnumerable<LinkResource> BuildLinks(SernosCount sernosCount)
        {
            yield return new LinkResource
                             {
                                 Rel = "self",
                                 Href = this.GetLocation(sernosCount)
                             };
        }
    }
}