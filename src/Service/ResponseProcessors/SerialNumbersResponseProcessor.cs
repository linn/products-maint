namespace Linn.Products.Service.ResponseProcessors
{
    using System.Collections.Generic;

    using Linn.Common.Facade;
    using Linn.Common.Nancy.Facade;
    using Linn.Products.Domain.Linnapps;

    public class SerialNumbersResponseProcessor : JsonResponseProcessor<ResponseModel<IEnumerable<SerialNumber>>>
    {
        public SerialNumbersResponseProcessor(IResourceBuilder<ResponseModel<IEnumerable<SerialNumber>>> resourceBuilder)
            : base(resourceBuilder, "serial-numbers", 1)
        {
        }
    }
}