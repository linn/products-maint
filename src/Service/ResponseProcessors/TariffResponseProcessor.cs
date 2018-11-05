namespace Linn.Products.Service.ResponseProcessors
{
    using Common.Facade;
    using Common.Nancy.Facade;
    using Domain.Linnapps.Products;

    public class TariffResponseProcessor : JsonResponseProcessor<Tariff>
    {
        public TariffResponseProcessor(IResourceBuilder<Tariff> resourceBuilder)
            : base(resourceBuilder, "tariff", 1)
        {
        }
    }
}