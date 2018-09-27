namespace Linn.Products.Facade.ResourceBuilders
{
    using System.Collections.Generic;
    using System.Linq;
    using Common.Facade;
    using Domain.Products;

    public class TariffsResourceBuilder : IResourceBuilder<IEnumerable<Tariff>>
    {
        private readonly TariffResourceBuilder resourceBuilder = new TariffResourceBuilder();

        public object Build(IEnumerable<Tariff> tariffs)
        {
            return tariffs.Select(t => this.resourceBuilder.Build(t));
        }

        public string GetLocation(IEnumerable<Tariff> tariffs) => $"/products/maint/tariffs";
    }
}