namespace Linn.Products.Facade.ResourceBuilders
{
    using System.Collections.Generic;
    using System.Linq;

    using Linn.Common.Facade;
    using Linn.Common.Resources;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    public class TypeOfSaleResourceBuilder : IResourceBuilder<TypeOfSale>
    {
        public object Build(TypeOfSale typeOfSale)
        {
            return new TypeOfSaleResource
                       {
                           Name = typeOfSale.Name,
                           Description = typeOfSale.Description,
                           Department = typeOfSale.Department,
                           Nominal = typeOfSale.Nominal,
                           RealSale = typeOfSale.RealSale,
                           Links = this.BuildLinks(typeOfSale).ToArray()
                       };
        }

        public string GetLocation(TypeOfSale typeOfSale)
        {
            return $"/products/maint/types-of-sale/{typeOfSale.Name}";
        }

        private IEnumerable<LinkResource> BuildLinks(TypeOfSale typeOfSale)
        {
            yield return new LinkResource
                             {
                                 Rel = "self",
                                 Href = this.GetLocation(typeOfSale)
                             };
        }
    }
}
