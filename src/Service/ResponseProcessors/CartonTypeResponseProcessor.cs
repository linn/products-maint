namespace Linn.Products.Service.ResponseProcessors
{
    using Linn.Common.Facade;
    using Linn.Common.Nancy.Facade;
    using Linn.Products.Domain.Linnapps;

    public class CartonTypeResponseProcessor : JsonResponseProcessor<CartonType>
    {
        public CartonTypeResponseProcessor(IResourceBuilder<CartonType> resourceBuilder)
            : base(resourceBuilder, "carton-type", 1)
        {
        }
    }
}