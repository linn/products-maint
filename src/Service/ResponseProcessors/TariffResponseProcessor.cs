namespace Linn.Products.Service.ResponseProcessors
{
    using Linn.Common.Facade;
    using Linn.Common.Nancy.Facade;
    using Linn.Products.Domain.Linnapps.Products;

    public class TariffResponseProcessor : JsonResponseProcessor<ResponseModel<Tariff>>
    {
        public TariffResponseProcessor(IResourceBuilder<ResponseModel<Tariff>> resourceBuilder)
            : base(resourceBuilder, "tariff", 1)
        {
        }
    }
}
