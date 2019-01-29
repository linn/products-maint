namespace Linn.Products.Service.ResponseProcessors
{
    using System.Collections.Generic;

    using Linn.Common.Facade;
    using Linn.Common.Nancy.Facade;
    using Linn.Products.Domain.Linnapps.Products;

    public class TariffsResponseProcessor : JsonResponseProcessor<IEnumerable<Tariff>>
    {
        public TariffsResponseProcessor(IResourceBuilder<IEnumerable<Tariff>> resourceBuilder)
            : base(resourceBuilder, "tariffs", 1)
        {
        }
    }
}
