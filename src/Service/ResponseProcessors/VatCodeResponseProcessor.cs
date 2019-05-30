namespace Linn.Products.Service.ResponseProcessors
{
    using Linn.Common.Facade;
    using Linn.Common.Nancy.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Facade.Models;

    public class VatCodeResponseProcessor : JsonResponseProcessor<ResponseModel<VatCode>>
    {
        public VatCodeResponseProcessor(IResourceBuilder<ResponseModel<VatCode>> resourceBuilder)
            : base(resourceBuilder, "vat-code", 1)
        {
        }
    }
}