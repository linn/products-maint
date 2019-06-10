namespace Linn.Products.Service.ResponseProcessors
{
    using Linn.Common.Facade;
    using Linn.Common.Nancy.Facade;
    using Linn.Products.Domain.Linnapps;

    public class ArchiveSerialNumberResponseProcessor : JsonResponseProcessor<ResponseModel<ArchiveSerialNumber>>
    {
        public ArchiveSerialNumberResponseProcessor(IResourceBuilder<ResponseModel<ArchiveSerialNumber>> resourceBuilder)
            : base(resourceBuilder, "archive-serial-number", 1)
        {
        }
    }
}
