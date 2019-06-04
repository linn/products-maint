namespace Linn.Products.Facade.ResourceBuilders
{
    using System.Collections.Generic;
    using System.Linq;

    using Linn.Common.Facade;
    using Linn.Common.Resources;
    using Linn.Products.Domain;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    public class SernosNoteResourceBuilder : IResourceBuilder<ResponseModel<SernosNote>>
    {
        private readonly IAuthorisationService authorisationService = new AuthorisationService();

        public SernosNoteResource Build(ResponseModel<SernosNote> sernosNoteModel)
        {
            return new SernosNoteResource
                       {
                           SernosGroup = sernosNoteModel.ResponseData.SernosGroup,
                           SernosNoteId = sernosNoteModel.ResponseData.SernosNoteId,
                           SernosNotes = sernosNoteModel.ResponseData.SernosNotes,
                           SernosNumber = sernosNoteModel.ResponseData.SernosNumber,
                           SernosTRef = sernosNoteModel.ResponseData.SernosTRef,
                           TransCode = sernosNoteModel.ResponseData.TransCode,
                           Links = this.BuildLinks(sernosNoteModel).ToArray()
                       };
        }

        public string GetLocation(ResponseModel<SernosNote> sernosNoteModel)
        {
            return $"/products/maint/serial-numbers/notes/{sernosNoteModel.ResponseData.SernosNoteId}";
        }

        object IResourceBuilder<ResponseModel<SernosNote>>.Build(ResponseModel<SernosNote> sernosNoteModel) => this.Build(sernosNoteModel);
        
        private IEnumerable<LinkResource> BuildLinks(ResponseModel<SernosNote> sernosNoteModel)
        {
            yield return new LinkResource
                             {
                                 Rel = "self",
                                 Href = this.GetLocation(sernosNoteModel)
                             };

            if (this.authorisationService.HasPermissionFor(AuthorisedAction.SerialNumberAdmin, sernosNoteModel.Privileges))
            {
                yield return new LinkResource { Rel = "edit", Href = this.GetLocation(sernosNoteModel) };
            }
        }
    }
}
