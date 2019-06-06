namespace Linn.Products.Service.ResponseProcessors
{
    using Linn.Common.Facade;
    using Linn.Common.Nancy.Facade;
    using Linn.Products.Domain.Linnapps;

    public class SerialNumberResponseProcessor : JsonResponseProcessor<ResponseModel<SerialNumber>>
    {
        public SerialNumberResponseProcessor(IResourceBuilder<ResponseModel<SerialNumber>> resourceBuilder)
            : base(resourceBuilder, "serial-number", 1)
        {
        }
    }
}