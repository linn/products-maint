namespace Linn.Products.Facade.Services
{
    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Domain.Linnapps.Repositories;
    using Linn.Products.Resources;

    public class CartonTypeService : ICartonTypeService
    {
        private readonly ICartonTypeRepository cartonTypeRepository;

        public CartonTypeService(ICartonTypeRepository cartonTypeRepository)
        {
            this.cartonTypeRepository = cartonTypeRepository;
        }

        public IResult<CartonType> GetCartonType(string name)
        {
            var cartonType = this.cartonTypeRepository.GetCarton(name);
            if (cartonType == null)
            {
                return new NotFoundResult<CartonType>();
            }

            return new SuccessResult<CartonType>(cartonType);
        }

        public IResult<CartonType> AddCartonType(CartonTypeResource resource)
        {
            var cartonType = new CartonType
                                 {
                                     Name = resource.Name,
                                     Description = resource.Description,
                                     Depth = resource.Depth,
                                     Width = resource.Width,
                                     Height = resource.Height,
                                     NumberOfLargeLabels = resource.NumberOfLargeLabels,
                                     NumberOfSmallLabels = resource.NumberOfSmallLabels
                                 };
            this.cartonTypeRepository.Add(cartonType);

            return new CreatedResult<CartonType>(cartonType);
        }

        public IResult<CartonType> UpdateCartonType(string name, CartonTypeUpdateResource resource)
        {
            var cartonType = this.cartonTypeRepository.GetCarton(name);
            if (cartonType == null)
            {
                return new NotFoundResult<CartonType>();
            }

            cartonType.Description = resource.Description;
            cartonType.Depth = resource.Depth;
            cartonType.Width = resource.Width;
            cartonType.Height = resource.Height;
            cartonType.NumberOfLargeLabels = resource.NumberOfLargeLabels;
            cartonType.NumberOfSmallLabels = resource.NumberOfSmallLabels;

            return new SuccessResult<CartonType>(cartonType);
        }
    }
}