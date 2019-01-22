namespace Linn.Products.Facade.ResourceBuilders
{
    using System.Collections.Generic;
    using System.Linq;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;

    public class TypesOfSaleResourceBuilder : IResourceBuilder<IEnumerable<TypeOfSale>>
    {
        private readonly TypeOfSaleResourceBuilder typeOfSaleResourceBuilder = new TypeOfSaleResourceBuilder();

        public object Build(IEnumerable<TypeOfSale> typesOfSale)
        {
            return typesOfSale.Select(a => this.typeOfSaleResourceBuilder.Build(a));
        }

        object IResourceBuilder<IEnumerable<TypeOfSale>>.Build(IEnumerable<TypeOfSale> typesOfSale) => this.Build(typesOfSale);

        public string GetLocation(IEnumerable<TypeOfSale> typesOfSale)
        {
            throw new System.NotImplementedException();
        }
    }
}
