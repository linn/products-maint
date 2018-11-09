namespace Linn.Products.Facade.ResourceBuilders
{
    using System.Collections.Generic;
    using System.Linq;

    using Linn.Common.Facade;
    using Linn.Common.Resources;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    public class SACoreTypeResourceBuilder : IResourceBuilder<SACoreType>
    {
        public SACoreTypeResource Build(SACoreType sACoreType)
        {
            return new SACoreTypeResource
                       {
                            coreType = sACoreType.CoreType,
                            Description  = sACoreType.Description,
                            DateInvalid = sACoreType.DateInvalid?.ToString("o"),
                            SortOrder = sACoreType.SortOrder,
                            TriggerLevel = sACoreType.TriggerLevel,
                            LookAheadDays = sACoreType.LookAheadDays,
                            Links = this.BuildLinks(sACoreType).ToArray()
                       };
        }

        object IResourceBuilder<SACoreType>.Build(SACoreType SACoreType) => this.Build(SACoreType);

        public string GetLocation(SACoreType SACoreType)
        {
            return $"/products/maint/sa-core-types/{SACoreType.CoreType}";
        }

        private IEnumerable<LinkResource> BuildLinks(SACoreType SACoreType)
        {
            yield return new LinkResource
                             {
                                 Rel = "self",
                                 Href = this.GetLocation(SACoreType)
                             };
        }
    }
}