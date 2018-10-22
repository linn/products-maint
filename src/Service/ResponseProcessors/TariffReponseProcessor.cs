namespace Linn.Products.Service.ResponseProcessors
{
    using Common.Facade;
    using Common.Nancy.Facade;
    using Domain.Linnapps.Products;

    public class TariffReponseProcessor : JsonResponseProcessor<Tariff>
    {
        public TariffReponseProcessor(IResourceBuilder<Tariff> resourceBuilder)
            : base(resourceBuilder, "tariff", 1)
        {
        }
    }
}