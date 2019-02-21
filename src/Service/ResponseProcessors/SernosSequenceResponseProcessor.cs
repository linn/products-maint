namespace Linn.Products.Service.ResponseProcessors
{
    using Linn.Common.Facade;
    using Linn.Common.Nancy.Facade;
    using Linn.Products.Domain.Linnapps;

    public class SernosSequenceResponseProcessor : JsonResponseProcessor<SernosSequence>
    {
        public SernosSequenceResponseProcessor(IResourceBuilder<SernosSequence> resourceBuilder)
            : base(resourceBuilder, "sernos-sequence", 1)
        {
        }
    }
}