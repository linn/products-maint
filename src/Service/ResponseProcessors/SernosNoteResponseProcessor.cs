namespace Linn.Products.Service.ResponseProcessors
{
    using Linn.Common.Facade;
    using Linn.Common.Nancy.Facade;
    using Linn.Products.Domain.Linnapps;

    public class SernosNoteResponseProcessor : JsonResponseProcessor<SernosNote>
    {
        public SernosNoteResponseProcessor(IResourceBuilder<SernosNote> resourceBuilder)
            : base(resourceBuilder, "sernos-note", 1)
        {
        }
    }
}