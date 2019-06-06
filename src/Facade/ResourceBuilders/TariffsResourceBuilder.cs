namespace Linn.Products.Facade.ResourceBuilders
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using Linn.Common.Facade;
    using Linn.Common.Resources;
    using Linn.Products.Domain;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Resources;

    public class TariffsResourceBuilder : IResourceBuilder<ResponseModel<IEnumerable<Tariff>>>
    {
        private readonly TariffResourceBuilder resourceBuilder = new TariffResourceBuilder();

        private readonly IAuthorisationService authorisationService = new AuthorisationService();

        public ResponseResource<IEnumerable<TariffResource>> Build(ResponseModel<IEnumerable<Tariff>> tariffs)
        {
            return new ResponseResource<IEnumerable<TariffResource>>
                               {
                                   ResponseData = tariffs.ResponseData.Select(
                                       trf => this.resourceBuilder.Build(
                                           new ResponseModel<Tariff>(trf, tariffs.Privileges))),
                                   Links = this.BuildLinks(tariffs).ToArray()
                               }; 
        }

        object IResourceBuilder<ResponseModel<IEnumerable<Tariff>>>.Build(ResponseModel<IEnumerable<Tariff>> tariffs) =>
            this.Build(tariffs);

        public string GetLocation(ResponseModel<IEnumerable<Tariff>> tariffs) => $"/products/maint/tariffs";

        private IEnumerable<LinkResource> BuildLinks(ResponseModel<IEnumerable<Tariff>> tariffs)
        {
            if (this.authorisationService.HasPermissionFor(AuthorisedAction.TariffAdmin, tariffs.Privileges))
            {
                yield return new LinkResource { Rel = "create", Href = "/products/maint/tariffs" };
            }
        }
    }
}
