namespace Linn.Products.Facade.ResourceBuilders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Linn.Common.Facade;
    using Linn.Common.Resources;
    using Linn.Products.Domain;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    public class VatCodesResourceBuilder : IResourceBuilder<ResponseModel<IEnumerable<VatCode>>>
    {
        private readonly VatCodeResourceBuilder vatCodeResourceBuilder = new VatCodeResourceBuilder();

        private readonly IAuthorisationService authorisationService = new AuthorisationService();

        public ResponseResource<IEnumerable<VatCodeResource>> Build(ResponseModel<IEnumerable<VatCode>> vatCodesModel)
        {
            var response = new ResponseResource<IEnumerable<VatCodeResource>>
                               {
                                   ResponseData = vatCodesModel.ResponseData.Select(
                                       a => this.vatCodeResourceBuilder.Build(
                                           new ResponseModel<VatCode>(a, vatCodesModel.Privileges))),
                                   Links = this.BuildLinks(vatCodesModel).ToArray()
                               };
            return response;
        }

        public string GetLocation(ResponseModel<IEnumerable<VatCode>> vatCodes)
        {
            throw new NotImplementedException();
        }

        object IResourceBuilder<ResponseModel<IEnumerable<VatCode>>>.Build(ResponseModel<IEnumerable<VatCode>> vatCodesModel) =>
            this.Build(vatCodesModel);

        private IEnumerable<LinkResource> BuildLinks(ResponseModel<IEnumerable<VatCode>> vatCodesModel)
        {
            if (this.authorisationService.HasPermissionFor(AuthorisedAction.VatAdmin, vatCodesModel.Privileges))
            {
                yield return new LinkResource { Rel = "create", Href = "/products/maint/vat-codes" };
            }
        }
    }
}