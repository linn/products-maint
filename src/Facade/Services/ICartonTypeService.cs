namespace Linn.Products.Facade.Services
{
    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    public interface ICartonTypeService
    {
        IResult<CartonType> GetCartonType(string name);

        IResult<CartonType> AddCartonType(CartonTypeResource resource);
    }
}
