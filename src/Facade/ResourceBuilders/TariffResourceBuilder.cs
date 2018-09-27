namespace Linn.Products.Facade.ResourceBuilders
{
    using System.Collections.Generic;
    using System.Linq;
    using Common.Facade;
    using Common.Resources;
    using Domain.Products;
    using Resources;

    public class TariffResourceBuilder : IResourceBuilder<Tariff>
    {
        public object Build(Tariff tariff)
        {
            return new TariffResource
            {
                TariffCode = tariff.TariffCode,
                Description = tariff.Description,
                USTariffCode = tariff.USTariffCode,
                Duty = tariff.Duty,
                DateInvalid = tariff.DateInvalid,
                Links = this.BuildLinks(tariff).ToArray()
            };
        }

        private IEnumerable<LinkResource> BuildLinks(Tariff tariff)
        {
            yield return new LinkResource("self", this.GetLocation(tariff));
        }

        public string GetLocation(Tariff tariff) => $"/products/maint/tariffs/{tariff.Id}";
    }
}