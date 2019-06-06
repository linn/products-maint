namespace Linn.Products.Facade.ResourceBuilders
{
    using System.Collections.Generic;
    using System.Linq;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    public class SernosNotesResourceBuilder : IResourceBuilder<IEnumerable<SernosNote>>
    {
        private readonly SernosNoteResourceBuilder sernosNoteResourceBuilder = new SernosNoteResourceBuilder();

        public IEnumerable<SernosNoteResource> Build(IEnumerable<SernosNote> sernosNotes)
        {
            return sernosNotes.Select(s => this.sernosNoteResourceBuilder.Build(s));
        }

        public string GetLocation(IEnumerable<SernosNote> model)
        {
            throw new System.NotImplementedException();
        }

        object IResourceBuilder<IEnumerable<SernosNote>>.Build(IEnumerable<SernosNote> sernosNotes) => this.Build(sernosNotes);
    }
}
