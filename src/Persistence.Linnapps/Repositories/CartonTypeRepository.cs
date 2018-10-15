namespace Linn.Products.Persistence.Linnapps.Repositories
{
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Domain.Linnapps.Repositories;

    public class CartonTypeRepository : ICartonTypeRepository
    {
        public CartonType GetCarton(string name)
        {
            return new CartonType("Carton 2", 3m, 2m, 1m)
                       {
                           Description = "Carton 2 Description",
                           NumberOfLargeLabels = 1,
                           NumberOfSmallLabels = 0
                       };
        }

        public void Add(CartonType cartonType)
        {
        }
    }
}