namespace Linn.Products.Facade.ResourceBuilders
{
    using System.Collections.Generic;
    using System.Linq;

    using Linn.Common.Facade;
    using Linn.Common.Resources;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    public class SernosNoteResourceBuilder : IResourceBuilder<ResponseModel<SernosNote>>
    {
        public SernosNoteResource Build(ResponseModel<SernosNote> sernosNoteModel)
        {
            return new SernosNoteResource
                       {
                           SernosGroup = sernosNoteModel.Entity.SernosGroup,
                           SernosNoteId = sernosNoteModel.Entity.SernosNoteId,
                           SernosNotes = sernosNoteModel.Entity.SernosNotes,
                           SernosNumber = sernosNoteModel.Entity.SernosNumber,
                           SernosTRef = sernosNoteModel.Entity.SernosTRef,
                           TransCode = sernosNoteModel.Entity.TransCode,
                           Links = this.BuildLinks(sernosNoteModel).ToArray()
                       };
        }

        public string GetLocation(ResponseModel<SernosNote> sernosNoteModel)
        {
            return $"/products/maint/serial-numbers/notes/{sernosNoteModel.Entity.SernosNoteId}";
        }

        object IResourceBuilder<ResponseModel<SernosNote>>.Build(ResponseModel<SernosNote> sernosNoteModel) => this.Build(sernosNoteModel);
        
        private IEnumerable<LinkResource> BuildLinks(ResponseModel<SernosNote> sernosNoteModel)
        {
            yield return new LinkResource
                             {
                                 Rel = "self",
                                 Href = this.GetLocation(sernosNoteModel)
                             };
        }
    }
}
