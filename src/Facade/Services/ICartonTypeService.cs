namespace Linn.Products.Facade.Services
{
    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;

    public interface ICartonTypeService
    {
        IResult<CartonType> GetCartonType(string name);
    }
}
