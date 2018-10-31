namespace Linn.Products.Facade.ResourceBuilders
{
    using System.Collections.Generic;
    using System.Linq;

    using Linn.Common.Facade;
    using Linn.Common.Resources;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    public class SernosConfigResourceBuilder : IResourceBuilder<SernosConfig>
    {
        public SernosConfigResource Build(SernosConfig sernosConfig)
        {
            return new SernosConfigResource
                       {
                           Description = sernosConfig.Description,
                           Name = sernosConfig.Name,
                           NumberOfBoxes = sernosConfig.NumberOfBoxes,
                           NumberOfSernos = sernosConfig.NumberOfSernos,
                           SerialNumbered = sernosConfig.SerialNumbered,
                           StartOn = sernosConfig.StartOn,
                           Links = this.BuildLinks(sernosConfig).ToArray()
            };
        }

        object IResourceBuilder<SernosConfig>.Build(SernosConfig sernosConfig) => this.Build(sernosConfig);

        public string GetLocation(SernosConfig sernosConfig)
        {
            return $"/products/maint/sernos-configs/{sernosConfig.Name}";
        }

        private IEnumerable<LinkResource> BuildLinks(SernosConfig sernosConfig)
        {
            yield return new LinkResource
                             {
                                 Rel = "self",
                                 Href = this.GetLocation(sernosConfig)
                             };
        }
    }
}