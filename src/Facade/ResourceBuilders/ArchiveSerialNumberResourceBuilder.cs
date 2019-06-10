namespace Linn.Products.Facade.ResourceBuilders
{
    using System.Collections.Generic;
    using System.Linq;

    using Linn.Common.Facade;
    using Linn.Common.Resources;
    using Linn.Products.Domain;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    public class ArchiveSerialNumberResourceBuilder : IResourceBuilder<ResponseModel<ArchiveSerialNumber>>
    {
        private readonly IAuthorisationService authorisationService = new AuthorisationService();

        public ArchiveSerialNumberResource Build(ResponseModel<ArchiveSerialNumber> archiveSerialNumberModel)
        {
            return new ArchiveSerialNumberResource
                       {
                           SernosNumber = archiveSerialNumberModel.ResponseData.SernosNumber,
                           AccountId = archiveSerialNumberModel.ResponseData.AccountId,
                           ArticleNumber = archiveSerialNumberModel.ResponseData.ArticleNumber,
                           CreatedBy = archiveSerialNumberModel.ResponseData.CreatedBy,
                           DocumentLine = archiveSerialNumberModel.ResponseData.DocumentLine,
                           DocumentNumber = archiveSerialNumberModel.ResponseData.DocumentNumber,
                           DocumentType = archiveSerialNumberModel.ResponseData.DocumentType,
                           OutletNumber = archiveSerialNumberModel.ResponseData.OutletNumber,
                           SernosDate = archiveSerialNumberModel.ResponseData.SernosDate?.ToString("o"),
                           SernosGroup = archiveSerialNumberModel.ResponseData.SernosGroup,
                           TransCode = archiveSerialNumberModel.ResponseData.TransCode,
                           Links = this.BuildLinks(archiveSerialNumberModel).ToArray()
                       };
        }

        public string GetLocation(ResponseModel<ArchiveSerialNumber> model)
        {
            throw new System.NotImplementedException();
        }

        object IResourceBuilder<ResponseModel<ArchiveSerialNumber>>.Build(
            ResponseModel<ArchiveSerialNumber> archiveSerialNumberModel) =>
            this.Build(archiveSerialNumberModel);

        private IEnumerable<LinkResource> BuildLinks(ResponseModel<ArchiveSerialNumber> archiveSerialNumberModel)
        {
            if (this.authorisationService.HasPermissionFor(
                AuthorisedAction.SerialNumberAdmin,
                archiveSerialNumberModel.Privileges))
            {
                yield return new LinkResource { Rel = "amend-serial-number", Href = "/products/maint/serial-numbers/notes" };

                yield return new LinkResource { Rel = "create-serial-number", Href = "/products/maint/serial-numbers/create" };
            }
        }
    }
}
