namespace Linn.Products.Service.ResponseProcessors
{
    using Linn.Common.Facade;
    using Linn.Common.Nancy.Facade;
    using Linn.Products.Domain.Linnapps.Products;

    public class TariffResponseProcessor : JsonResponseProcessor<Tariff>
    {
        public TariffResponseProcessor(IResourceBuilder<Tariff> resourceBuilder)
            : base(resourceBuilder, "tariff", 1)
        {
        }
    }
}