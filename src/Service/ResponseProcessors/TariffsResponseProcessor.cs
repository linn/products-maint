namespace Linn.Products.Service.ResponseProcessors
{
    using System.Collections.Generic;

    using Linn.Common.Facade;
    using Linn.Common.Nancy.Facade;
    using Linn.Products.Domain.Linnapps.Products;

    public class TariffsResponseProcessor : JsonResponseProcessor<ResponseModel<IEnumerable<Tariff>>>
    {
        public TariffsResponseProcessor(IResourceBuilder<ResponseModel<IEnumerable<Tariff>>> resourceBuilder)
            : base(resourceBuilder, "tariffs", 1)
        {
        }
    }
}
