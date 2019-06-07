namespace Linn.Products.Facade.ResourceBuilders
{
    using System.Collections.Generic;
    using System.Linq;

    using Linn.Common.Facade;
    using Linn.Common.Resources;
    using Linn.Products.Domain;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Resources;

    public class TariffResourceBuilder : IResourceBuilder<ResponseModel<Tariff>>
    {
        private readonly IAuthorisationService authorisationService = new AuthorisationService();

        public object Build(ResponseModel<Tariff> tariff)
        {
            return new TariffResource
            {
                TariffCode = tariff.ResponseData.TariffCode,
                Description = tariff.ResponseData.Description,
                USTariffCode = tariff.ResponseData.USTariffCode,
                Id = tariff.ResponseData.Id,
                Duty = tariff.ResponseData.Duty,
                DateInvalid = tariff.ResponseData.DateInvalid?.ToString("o"),
                Links = this.BuildLinks(tariff).ToArray()
            };
        }

        object IResourceBuilder<ResponseModel<Tariff>>.Build(ResponseModel<Tariff> r) => this.Build(r);

        public string GetLocation(ResponseModel<Tariff> tariff) => $"/products/maint/tariffs/{tariff.ResponseData.Id}";

        private IEnumerable<LinkResource> BuildLinks(ResponseModel<Tariff> tariff)
        {
            yield return new LinkResource("self", this.GetLocation(tariff));

            if (this.authorisationService.HasPermissionFor(AuthorisedAction.TariffAdmin, tariff.Privileges))
            {
                yield return new LinkResource("edit", this.GetLocation(tariff));
            }

            if (tariff.ResponseData.EnteredBy.HasValue)
            {
                yield return new LinkResource("entered-by", $"/employees/{tariff.ResponseData.EnteredBy}");
            }

            if (tariff.ResponseData.ChangedBy.HasValue)
            {
                yield return new LinkResource("changed-by", $"/employees/{tariff.ResponseData.ChangedBy}");
            }
        }
    }
}
