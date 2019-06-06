namespace Linn.Products.Facade.ResourceBuilders
{
    using System.Collections.Generic;
    using System.Linq;

    using Linn.Common.Facade;
    using Linn.Common.Resources;
    using Linn.Products.Domain;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    public class SernosNotesResourceBuilder : IResourceBuilder<ResponseModel<IEnumerable<SernosNote>>>
    {
        private readonly SernosNoteResourceBuilder sernosNoteResourceBuilder = new SernosNoteResourceBuilder();

        private readonly IAuthorisationService authorisationService = new AuthorisationService();

        public ResponseResource<IEnumerable<SernosNoteResource>> Build(ResponseModel<IEnumerable<SernosNote>> sernosNotesModel)
        {
            var response = new ResponseResource<IEnumerable<SernosNoteResource>>
                               {
                                   ResponseData =
                                       sernosNotesModel.ResponseData.Select(
                                           s => this.sernosNoteResourceBuilder.Build(
                                               new ResponseModel<SernosNote>(s, null))),
                                   Links = this.BuildLinks(sernosNotesModel).ToArray()
                               };

            return response;
        }

        public string GetLocation(ResponseModel<IEnumerable<SernosNote>> model)
        {
            throw new System.NotImplementedException();
        }

        object IResourceBuilder<ResponseModel<IEnumerable<SernosNote>>>.Build(ResponseModel<IEnumerable<SernosNote>> sernosNotesModel) =>
            this.Build(sernosNotesModel);

        private IEnumerable<LinkResource> BuildLinks(ResponseModel<IEnumerable<SernosNote>> sernosNoteModel)
        {
            if (this.authorisationService.HasPermissionFor(AuthorisedAction.SerialNumberAdmin, sernosNoteModel.Privileges))
            {
                yield return new LinkResource { Rel = "create", Href = "/products/maint/serial-numbers" };
            }
        }
    }
}
