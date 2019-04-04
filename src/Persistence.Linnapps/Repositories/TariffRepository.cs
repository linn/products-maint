namespace Linn.Products.Persistence.Linnapps.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using Linn.Common.Persistence;
    using Linn.Products.Domain.Linnapps.Products;

    public class TariffRepository : IRepository<Tariff, int>
    {
        private readonly ServiceDbContext serviceDbContext;

        public TariffRepository(ServiceDbContext serviceDbContext)
        {
            this.serviceDbContext = serviceDbContext;
        }

        public Tariff FindById(int id)
        {
            return this.serviceDbContext.Tariffs.Where(t => t.Id == id).ToList().FirstOrDefault();
        }

        public IQueryable<Tariff> FindAll()
        {
            return this.serviceDbContext.Tariffs;
        }

        public void Add(Tariff tariff)
        {
            var nextId = this.serviceDbContext.Tariffs.Max(t => t.Id) + 1;

            tariff.Id = nextId;

            this.serviceDbContext.Tariffs.Add(tariff);
        }

        public void Remove(Tariff entity)
        {
            throw new NotImplementedException();
        }

        public Tariff FindBy(Expression<Func<Tariff, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Tariff> FilterBy(Expression<Func<Tariff, bool>> expression)
        {
            return this.serviceDbContext.Tariffs.Where(expression);
        }
    }
}
