namespace Linn.Products.Service.ResponseProcessors
{
    using System.Collections.Generic;

    using Linn.Common.Facade;
    using Linn.Common.Nancy.Facade;
    using Linn.Products.Domain.Linnapps;

    public class VatCodesResponseProcessor : JsonResponseProcessor<IEnumerable<VatCode>>
    {
        public VatCodesResponseProcessor(IResourceBuilder<IEnumerable<VatCode>> resourceBuilder)
            : base(resourceBuilder, "vat-codes", 1)
        {
        }
    }
}