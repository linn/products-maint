namespace Linn.Products.Facade.ResourceBuilders
{
    using System.Collections.Generic;
    using System.Linq;

    using Linn.Common.Facade;
    using Linn.Common.Resources;
    using Linn.Products.Domain;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    public class VatCodeResourceBuilder : IResourceBuilder<ResponseModel<VatCode>>
    {
        private readonly IAuthorisationService authorisationService = new AuthorisationService();

        public VatCodeResource Build(ResponseModel<VatCode> vatCodeModel)
        {
            return new VatCodeResource
                       {
                           Code = vatCodeModel.ResponseData.Code,
                           Description = vatCodeModel.ResponseData.Description,
                           Rate = vatCodeModel.ResponseData.Rate,
                           Reason = vatCodeModel.ResponseData.Reason,
                           VatOnly = vatCodeModel.ResponseData.VatOnly,
                           VatReturnId = vatCodeModel.ResponseData.VatReturnId,
                           Links = this.BuildLinks(vatCodeModel).ToArray()
                       };
        }

        public string GetLocation(ResponseModel<VatCode> vatCode)
        {
            return $"/products/maint/vat-codes/{vatCode.ResponseData.Code}";
        }

        object IResourceBuilder<ResponseModel<VatCode>>.Build(ResponseModel<VatCode> vatCodeModel) => this.Build(vatCodeModel);

        private IEnumerable<LinkResource> BuildLinks(ResponseModel<VatCode> vatCodeModel)
        {
            yield return new LinkResource { Rel = "self", Href = this.GetLocation(vatCodeModel) };

            if (this.authorisationService.HasPermissionFor(AuthorisedAction.VatAdmin, vatCodeModel.Privileges))
            {
                yield return new LinkResource { Rel = "edit", Href = this.GetLocation(vatCodeModel) };
            }
        }
    }
}