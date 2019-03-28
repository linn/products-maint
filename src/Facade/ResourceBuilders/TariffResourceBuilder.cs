namespace Linn.Products.Facade.ResourceBuilders
{
    using System.Collections.Generic;
    using System.Linq;

    using Linn.Common.Facade;
    using Linn.Common.Resources;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Resources;

    public class TariffResourceBuilder : IResourceBuilder<Tariff>
    {
        public object Build(Tariff tariff)
        {
            return new TariffResource
            {
                TariffCode = tariff.TariffCode,
                Description = tariff.Description,
                USTariffCode = tariff.USTariffCode,
                Id = tariff.Id,
                Duty = tariff.Duty,
                DateInvalid = tariff.DateInvalid?.ToString("o"),
                Links = this.BuildLinks(tariff).ToArray()
            };
        }

        public string GetLocation(Tariff tariff) => $"/products/maint/tariffs/{tariff.Id}";

        private IEnumerable<LinkResource> BuildLinks(Tariff tariff)
        {
            yield return new LinkResource("self", this.GetLocation(tariff));
        }
    }
}