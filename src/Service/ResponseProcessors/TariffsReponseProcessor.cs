namespace Linn.Products.Service.ResponseProcessors
{
    using System.Collections.Generic;
    using Common.Facade;
    using Common.Nancy.Facade;
    using Domain.Linnapps.Products;

    public class TariffsReponseProcessor : JsonResponseProcessor<IEnumerable<Tariff>>
    {
        public TariffsReponseProcessor(IResourceBuilder<IEnumerable<Tariff>> resourceBuilder)
            : base(resourceBuilder, "tariffs", 1)
        {
        }
    }
}
