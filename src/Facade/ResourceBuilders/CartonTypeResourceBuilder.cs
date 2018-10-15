namespace Linn.Products.Facade.ResourceBuilders
{
    using System.Collections.Generic;
    using System.Linq;

    using Linn.Common.Facade;
    using Linn.Common.Resources;
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
                           NumberOfSmallLabels = cartonType.NumberOfSmallLabels,
                           Links = this.BuildLinks(cartonType).ToArray()
            };
        }

        object IResourceBuilder<CartonType>.Build(CartonType cartonType) => this.Build(cartonType);

        public string GetLocation(CartonType cartonType)
        {
            return $"/products/maint/carton-types/{cartonType.Name}";
        }

        private IEnumerable<LinkResource> BuildLinks(CartonType cartonType)
        {
            yield return new LinkResource
                             {
                                 Rel = "self",
                                 Href = this.GetLocation(cartonType)
                             };
        }
    }
}