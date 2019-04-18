namespace Linn.Products.Facade.ResourceBuilders
{
    using System.Collections.Generic;
    using System.Linq;

    using Linn.Common.Facade;
    using Linn.Common.Resources;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    public class SernosTransResourceBuilder : IResourceBuilder<SernosTrans>
    {
        public SernosTransResource Build(SernosTrans sernosTrans)
        {
            return new SernosTransResource
                       {
                           TransCode = sernosTrans.TransCode,
                           TransDescription = sernosTrans.TransDescription,
                           Comments = sernosTrans.Comments,
                           Links = this.BuildLinks(sernosTrans).ToArray()
                       };
        }

        public string GetLocation(SernosTrans sernosTrans)
        {
            return $"/products/maint/sernos-trans/{sernosTrans.TransCode}";
        }

        object IResourceBuilder<SernosTrans>.Build(SernosTrans sernosTrans) => this.Build(sernosTrans);

        private IEnumerable<LinkResource> BuildLinks(SernosTrans sernosTrans)
        {
            yield return new LinkResource { Rel = "self", Href = this.GetLocation(sernosTrans) };
        }
    }
}
