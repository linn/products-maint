namespace Linn.Products.Facade.ResourceBuilders
{
    using System.Collections.Generic;
    using System.Linq;

    using Linn.Common.Facade;
    using Linn.Common.Resources;
    using Linn.Products.Domain;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    public class ArchiveSerialNumbersResourceBuilder : IResourceBuilder<ResponseModel<IEnumerable<ArchiveSerialNumber>>>
    {
        private readonly ArchiveSerialNumberResourceBuilder archiveSerialNumberResourceBuilder = new ArchiveSerialNumberResourceBuilder();

        private readonly IAuthorisationService authorisationService = new AuthorisationService();

        public ResponseResource<IEnumerable<ArchiveSerialNumberResource>> Build(ResponseModel<IEnumerable<ArchiveSerialNumber>> archiveSerialNumbersModel)
        {
            var response = new ResponseResource<IEnumerable<ArchiveSerialNumberResource>>
                               {
                                   ResponseData = archiveSerialNumbersModel.ResponseData.Select(
                                       s => this.archiveSerialNumberResourceBuilder.Build(
                                           new ResponseModel<ArchiveSerialNumber>(s, archiveSerialNumbersModel.Privileges))),
                                   Links = this.BuildLinks(archiveSerialNumbersModel).ToArray()
                               };

            return response;
        }

        public string GetLocation(ResponseModel<IEnumerable<ArchiveSerialNumber>> model)
        {
            throw new System.NotImplementedException();
        }

        object IResourceBuilder<ResponseModel<IEnumerable<ArchiveSerialNumber>>>.Build(
            ResponseModel<IEnumerable<ArchiveSerialNumber>> archiveSerialNumbersModel) =>
            this.Build(archiveSerialNumbersModel);

        private IEnumerable<LinkResource> BuildLinks(ResponseModel<IEnumerable<ArchiveSerialNumber>> archiveSerialNumbersModel)
        {
            if (this.authorisationService.HasPermissionFor(
                AuthorisedAction.SerialNumberAdmin,
                archiveSerialNumbersModel.Privileges))
            {
                yield return new LinkResource { Rel = "amend-serial-number", Href = "/products/maint/serial-numbers/notes" };

                yield return new LinkResource { Rel = "create-serial-number", Href = "/products/maint/serial-numbers/create" };
            }
        }
    }
}
