namespace Linn.Products.Facade.Services
{
    using System;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Domain.Linnapps.Exceptions;
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
            CartonType cartonType;

            try
            {
                cartonType = new CartonType(resource.Name, resource.Width, resource.Height, resource.Depth)
                                     {
                                         Description = resource.Description,
                                         NumberOfLargeLabels = 1,
                                         NumberOfSmallLabels = 0
                                     };
            }
            catch (IncompleteDataException exception)
            {
                return new BadRequestResult<CartonType>(exception.Message);
            }

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

            return new SuccessResult<CartonType>(cartonType);
        }
    }
}