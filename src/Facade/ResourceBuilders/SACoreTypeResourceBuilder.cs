namespace Linn.Products.Facade.ResourceBuilders
{
    using System.Collections.Generic;
    using System.Linq;

    using Linn.Common.Facade;
    using Linn.Common.Resources;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    public class SaCoreTypeResourceBuilder : IResourceBuilder<SaCoreType>
    {
        public SaCoreTypeResource Build(SaCoreType saCoreType)
        {
            return new SaCoreTypeResource
                       {
                            CoreType = saCoreType.CoreType,
                            Description  = saCoreType.Description,
                            DateInvalid = saCoreType.DateInvalid?.ToString("o"),
                            SortOrder = saCoreType.SortOrder,
                            TriggerLevel = saCoreType.TriggerLevel,
                            LookAheadDays = saCoreType.LookAheadDays,
                            Links = this.BuildLinks(saCoreType).ToArray()
                       };
        }

        object IResourceBuilder<SaCoreType>.Build(SaCoreType saCoreType) => this.Build(saCoreType);

        public string GetLocation(SaCoreType saCoreType)
        {
            return $"/products/maint/sa-core-types/{saCoreType.CoreType}";
        }

        private IEnumerable<LinkResource> BuildLinks(SaCoreType saCoreType)
        {
            yield return new LinkResource
                             {
                                 Rel = "self",
                                 Href = this.GetLocation(saCoreType)
                             };
        }
    }
}