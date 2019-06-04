namespace Linn.Products.Facade.ResourceBuilders
{
    using System.Collections.Generic;
    using System.Linq;

    using Linn.Common.Facade;
    using Linn.Common.Resources;
    using Linn.Products.Domain;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    public class SerialNumbersResourceBuilder : IResourceBuilder<ResponseModel<IEnumerable<SerialNumber>>>
    {
        private readonly SerialNumberResourceBuilder serialNumberResourceBuilder = new SerialNumberResourceBuilder();

        private readonly IAuthorisationService authorisationService = new AuthorisationService();

        public ResponseResource<IEnumerable<SerialNumberResource>> Build(ResponseModel<IEnumerable<SerialNumber>> serialNumbersModel)
        {
            var response = new ResponseResource<IEnumerable<SerialNumberResource>>
                               {
                                   ResponseData =
                                       serialNumbersModel.ResponseData.Select(
                                           s => this.serialNumberResourceBuilder.Build(
                                               new ResponseModel<SerialNumber>(s, serialNumbersModel.Privileges))),
                                   Links = this.BuildLinks(
                                       serialNumbersModel).ToArray()
                               };

            return response;
        }

        object IResourceBuilder<ResponseModel<IEnumerable<SerialNumber>>>.Build(ResponseModel<IEnumerable<SerialNumber>> serialNumbersModel) => this.Build(serialNumbersModel);

        public string GetLocation(ResponseModel<IEnumerable<SerialNumber>> model)
        {
            return "/products/maint/serial-numbers";
        }

        private IEnumerable<LinkResource> BuildLinks(ResponseModel<IEnumerable<SerialNumber>> serialNumbersModel)
        {
            if (this.authorisationService.HasPermissionFor(
                AuthorisedAction.SerialNumberAdmin,
                serialNumbersModel.Privileges))
            {
                // TODO see what rel should actuallybe in here
                yield return new LinkResource { Rel = "create", Href = "/products/maint/serial-numbers" };
            }
        }
    }
}
