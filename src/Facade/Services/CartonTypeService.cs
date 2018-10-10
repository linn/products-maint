namespace Linn.Products.Facade.Services
{
    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Domain.Linnapps.Repositories;

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
    }
}