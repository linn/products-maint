namespace Linn.Products.Persistence.Linnapps.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using Linn.Common.Persistence;
    using Linn.Products.Domain.Linnapps;

    public class CartonTypeRepository : IRepository<CartonType, string>
    {
        private readonly ServiceDbContext serviceDbContext;

        public CartonTypeRepository(ServiceDbContext serviceDbContext)
        {
            this.serviceDbContext = serviceDbContext;
        }

        public CartonType FindById(string key)
        {
            return this.serviceDbContext.CartonTypes.Where(a => a.Name == key).ToList().SingleOrDefault();
        }

        public IQueryable<CartonType> FindAll()
        {
            return this.serviceDbContext.CartonTypes;
        }

        public void Add(CartonType cartonType)
        {
            this.serviceDbContext.Add(cartonType);
        }

        public void Remove(CartonType entity)
        {
            throw new NotImplementedException();
        }

        public CartonType FindBy(Expression<Func<CartonType, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IQueryable<CartonType> FilterBy(Expression<Func<CartonType, bool>> expression)
        {
            throw new NotImplementedException();
        }
    }
}