namespace Linn.Products.Facade.ResourceBuilders
{
    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    public class CartonTypeResourceBuilder : IResourceBuilder<CartonType>
    {
        public CartonTypeResource Build(CartonType cartonType)
        {
            return new CartonTypeResource
                       {
                           Description = cartonType.Description,
                           Name = cartonType.Name,
                           Depth = cartonType.Depth,
                           Width = cartonType.Width,
                           Height = cartonType.Height,
                           NumberOfLargeLabels = cartonType.NumberOfLargeLabels,
                           NumberOfSmallLabels = cartonType.NumberOfSmallLabels
                       };
        }

        object IResourceBuilder<CartonType>.Build(CartonType cartonType) => this.Build(cartonType);

        public string GetLocation(CartonType cartonType)
        {
            return $"/products/maint/carton-types/{cartonType.Name}";
        }
    }
}