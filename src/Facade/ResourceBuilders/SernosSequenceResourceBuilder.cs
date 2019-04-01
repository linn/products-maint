namespace Linn.Products.Facade.ResourceBuilders
{
    using System.Collections.Generic;
    using System.Linq;
    using System;

    using Linn.Common.Facade;
    using Linn.Common.Resources;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    public class SernosSequenceResourceBuilder : IResourceBuilder<SernosSequence>
    {
        public SernosSequenceResource Build(SernosSequence sernosSequence)
        {
            return new SernosSequenceResource
                       {
                           SequenceName = sernosSequence.SequenceName,
                           Description = sernosSequence.Description,
                           DateClosed = sernosSequence.DateClosed?.ToString("o"),
                           NextSerialNumber = sernosSequence.NextSerialNumber,
                           Links = this.BuildLinks(sernosSequence).ToArray()
                       };
        }

        public string GetLocation(SernosSequence sernosSequence)
        {
            return $"/products/maint/sernos-sequences/{Uri.EscapeDataString(sernosSequence.SequenceName)}";
        }

        object IResourceBuilder<SernosSequence>.Build(SernosSequence sernosSequence) => this.Build(sernosSequence);

        private IEnumerable<LinkResource> BuildLinks(SernosSequence sernosSequence)
        {
            yield return new LinkResource { Rel = "self", Href = this.GetLocation(sernosSequence) };
        }
    }
}
