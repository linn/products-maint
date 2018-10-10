namespace Linn.Products.Persistence.Linnapps.Repositories
{
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Domain.Linnapps.Repositories;

    public class CartonTypeRepository : ICartonTypeRepository
    {
        public CartonType GetCarton(string name)
        {
            return new CartonType
                       {
                           Name = "Carton 2",
                           Description = "Carton 2 Description",
                           Depth = 1m,
                           Height = 2m,
                           Width = 3m,
                           NumberOfLargeLabels = 1,
                           NumberOfSmallLabels = 2
                       };
        }

        public void Add(CartonType cartonType)
        {
        }
    }
}