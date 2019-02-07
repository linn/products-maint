namespace Linn.Products.Persistence.Linnapps.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Domain.Linnapps.Repositories;

    public class TariffRepository : ITariffRepository
    {
        private readonly ServiceDbContext serviceDbContext;

        public TariffRepository(ServiceDbContext serviceDbContext)
        {
            this.serviceDbContext = serviceDbContext;
        }

        public IEnumerable<Tariff> SearchTariffs(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return this.serviceDbContext.Tariffs;
            }

            return this.serviceDbContext.Tariffs.Where(t =>
                t.TariffCode.Contains(searchTerm) || t.Description.ToLower().Contains(searchTerm.ToLower()));
        }

        public Tariff FindById(int id)
        {
            return this.serviceDbContext.Tariffs.Where(t => t.Id == id).ToList().FirstOrDefault();
        }

        public IQueryable<Tariff> FindAll()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
