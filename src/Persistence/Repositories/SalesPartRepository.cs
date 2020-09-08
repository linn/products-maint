namespace Linn.Products.Persistence.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using Linn.Common.Persistence;
    using Linn.Products.Domain;
    using Linn.Products.Domain.Linnapps.Products;

    using Microsoft.EntityFrameworkCore;

    public class SalesPartRepository : IRepository<SalesPart, int>
    {
        private readonly ProductsServiceDbContext serviceDbContext;

        public SalesPartRepository(ProductsServiceDbContext serviceDbContext)
        {
            this.serviceDbContext = serviceDbContext;
        }

        public SalesPart FindById(int key)
        {
            return this.serviceDbContext.SalesParts
                .Where(b => b.Id == key)
                .Include(a => a.TariffId)
                .Include(a => a.Description)
                .ToList().FirstOrDefault();
        }

        public IQueryable<SalesPart> FindAll()
        {
            return this.serviceDbContext.SalesParts;
        }

        public void Add(SalesPart entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(SalesPart entity)
        {
            throw new NotImplementedException();
        }

        public SalesPart FindBy(Expression<Func<SalesPart, bool>> expression)
        {
            return this.serviceDbContext.SalesParts.Where(expression).ToList().FirstOrDefault();
        }

        public IQueryable<SalesPart> FilterBy(Expression<Func<SalesPart, bool>> expression)
        {
            return this.serviceDbContext.SalesParts.Where(expression).Include(a => a.TariffId);
        }
    }
}