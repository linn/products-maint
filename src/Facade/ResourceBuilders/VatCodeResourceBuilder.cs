namespace Linn.Products.Facade.ResourceBuilders
{
    using System.Collections.Generic;
    using System.Linq;

    using Linn.Common.Facade;
    using Linn.Common.Resources;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    public class VatCodeResourceBuilder : IResourceBuilder<VatCode>
    {
        public VatCodeResource Build(VatCode vatCode)
        {
            return new VatCodeResource
                       {
                           Code = vatCode.Code,
                           Description = vatCode.Description,
                           Rate = vatCode.Rate,
                           Reason = vatCode.Reason,
                           VatOnly = vatCode.VatOnly,
                           VatReturnId = vatCode.VatReturnId,
                           Links = this.BuildLinks(vatCode).ToArray()
                       };
        }

        public string GetLocation(VatCode vatCode)
        {
            return $"/products/maint/vat-codes/{vatCode.Code}";
        }

        object IResourceBuilder<VatCode>.Build(VatCode vatCode) => this.Build(vatCode);

        private IEnumerable<LinkResource> BuildLinks(VatCode vatCode)
        {
            yield return new LinkResource { Rel = "self", Href = this.GetLocation(vatCode) };
        }
    }
}