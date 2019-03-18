namespace Linn.Products.Facade.ResourceBuilders
{
    using System.Collections.Generic;
    using System.Linq;

    using Linn.Common.Facade;
    using Linn.Common.Resources;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    public class SernosNoteResourceBuilder : IResourceBuilder<SernosNote>
    {
        public SernosNoteResource Build(SernosNote sernosNote)
        {
            return new SernosNoteResource
                       {
                           SernosGroup = sernosNote.SernosGroup,
                           SernosNoteId = sernosNote.SernosNoteId,
                           SernosNotes = sernosNote.SernosNotes,
                           SernosNumber = sernosNote.SernosNumber,
//                           SernosTref = sernosNote.SernosTref,
                           Links = this.BuildLinks(sernosNote).ToArray()
                       };
        }

        public string GetLocation(SernosNote sernosNote)
        {
            //            return $"/products/maint/{sernosNote.SernosTref}/notes/{sernosNote.SernosNoteId}";
            return $"/products/maint/1/notes/{sernosNote.SernosNoteId}";
        }

        object IResourceBuilder<SernosNote>.Build(SernosNote sernosNote) => this.Build(sernosNote);

        private IEnumerable<LinkResource> BuildLinks(SernosNote sernosNote)
        {
            yield return new LinkResource { Rel = "self", Href = this.GetLocation(sernosNote) };
        }
    }
}
