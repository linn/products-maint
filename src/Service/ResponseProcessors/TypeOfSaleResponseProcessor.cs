namespace Linn.Products.Service.ResponseProcessors
{
    using Linn.Common.Facade;
    using Linn.Common.Nancy.Facade;
    using Linn.Products.Domain.Linnapps;

    public class TypeOfSaleResponseProcessor : JsonResponseProcessor<TypeOfSale>
    {
        public TypeOfSaleResponseProcessor(IResourceBuilder<TypeOfSale> resourceBuilder)
            : base(resourceBuilder, "type-of-sale", 1)
        {
        }
    }
}
