namespace Linn.Products.Facade.ResourceBuilders
{
    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;

    public class CartonTypeResourceBuilder : IResourceBuilder<CartonType>
    {
        public CartonType Build(CartonType cartonType)
        {
            return cartonType;
        }

        object IResourceBuilder<CartonType>.Build(CartonType cartonType) => this.Build(cartonType);

        public string GetLocation(CartonType cartonType)
        {
            return $"/products/maint/carton-types/{cartonType.Name}";
        }
    }
}