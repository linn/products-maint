namespace Linn.Products.Facade.ResourceBuilders
{
    using System.Collections.Generic;
    using System.Linq;

    using Linn.Common.Facade;
    using Linn.Common.Resources;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Facade.Models;
    using Linn.Products.Resources;

    public class VatCodeResourceBuilder : IResourceBuilder<ResponseModel<VatCode>>
    {
        public VatCodeResource Build(ResponseModel<VatCode> vatCodeModel)
        {
            return new VatCodeResource
                       {
                           Code = vatCodeModel.Entity.Code,
                           Description = vatCodeModel.Entity.Description,
                           Rate = vatCodeModel.Entity.Rate,
                           Reason = vatCodeModel.Entity.Reason,
                           VatOnly = vatCodeModel.Entity.VatOnly,
                           VatReturnId = vatCodeModel.Entity.VatReturnId,
                           Links = this.BuildLinks(vatCodeModel).ToArray()
                       };
        }

        public string GetLocation(ResponseModel<VatCode> vatCode)
        {
            return $"/products/maint/vat-codes/{vatCode.Entity.Code}";
        }

        object IResourceBuilder<ResponseModel<VatCode>>.Build(ResponseModel<VatCode> vatCodeModel) => this.Build(vatCodeModel);

        private IEnumerable<LinkResource> BuildLinks(ResponseModel<VatCode> vatCode)
        {
            yield return new LinkResource { Rel = "self", Href = this.GetLocation(vatCode) };
        }
    }
}