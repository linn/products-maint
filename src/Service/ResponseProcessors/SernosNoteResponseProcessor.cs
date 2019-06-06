namespace Linn.Products.Service.ResponseProcessors
{
    using Linn.Common.Facade;
    using Linn.Common.Nancy.Facade;
    using Linn.Products.Domain.Linnapps;

    public class SernosNoteResponseProcessor : JsonResponseProcessor<ResponseModel<SernosNote>>
    {
        public SernosNoteResponseProcessor(IResourceBuilder<ResponseModel<SernosNote>> resourceBuilder)
            : base(resourceBuilder, "sernos-note", 1)
        {
        }
    }
}