namespace Linn.Products.Service.ResponseProcessors
{
    using Linn.Common.Facade;
    using Linn.Common.Nancy.Facade;
    using Linn.Products.Domain.Linnapps;

    public class VatCodeResponseProcessor : JsonResponseProcessor<VatCode>
    {
        public VatCodeResponseProcessor(IResourceBuilder<VatCode> resourceBuilder)
            : base(resourceBuilder, "vat-code", 1)
        {
        }
    }
}