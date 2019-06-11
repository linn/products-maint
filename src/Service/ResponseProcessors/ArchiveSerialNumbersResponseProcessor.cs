namespace Linn.Products.Service.ResponseProcessors
{
    using System.Collections.Generic;

    using Linn.Common.Facade;
    using Linn.Common.Nancy.Facade;
    using Linn.Products.Domain.Linnapps;

    public class ArchiveSerialNumbersResponseProcessor : JsonResponseProcessor<ResponseModel<IEnumerable<ArchiveSerialNumber>>>
    {
        public ArchiveSerialNumbersResponseProcessor(IResourceBuilder<ResponseModel<IEnumerable<ArchiveSerialNumber>>> resourceBuilder)
            : base(resourceBuilder, "archive-serial-numbers", 1)
        {
        }
    }
}
