namespace Linn.Products.Facade.ResourceBuilders
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps.Products;

    public class TariffsResourceBuilder : IResourceBuilder<IEnumerable<Tariff>>
    {
        private readonly TariffResourceBuilder resourceBuilder = new TariffResourceBuilder();

        public object Build(IEnumerable<Tariff> tariffs)
        {
            return tariffs.Select(t => this.resourceBuilder.Build(new ResponseModel<Tariff>(t,null)));
        }

        public string GetLocation(IEnumerable<Tariff> tariffs) => $"/products/maint/tariffs";
    }
}
