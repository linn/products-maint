namespace Linn.Products.Service.ResponseProcessors
{
    using System.Collections.Generic;

    using Linn.Common.Facade;
    using Linn.Common.Nancy.Facade;
    using Linn.Products.Domain.Linnapps;

    public class TypesOfSaleResponseProcessor : JsonResponseProcessor<IEnumerable<TypeOfSale>>
    {
        public TypesOfSaleResponseProcessor(IResourceBuilder<IEnumerable<TypeOfSale>> resourceBuilder)
            : base(resourceBuilder, "types-of-sale", 1)
        {
        }
    }
}
