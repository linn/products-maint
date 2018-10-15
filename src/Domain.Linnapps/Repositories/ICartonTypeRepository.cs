namespace Linn.Products.Domain.Linnapps.Repositories
{
    public interface ICartonTypeRepository
    {
        CartonType GetCarton(string name);

        void Add(CartonType cartonType);
    }
}
