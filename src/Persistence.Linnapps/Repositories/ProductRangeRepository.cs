namespace Linn.Products.Persistence.Linnapps.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using Linn.Common.Persistence;
    using Linn.Products.Domain.Linnapps.Products;

    using Microsoft.EntityFrameworkCore;

    public class ProductRangeRepository : IRepository<ProductRange, int>
    {
        private readonly ServiceDbContext serviceDbContext;

        public ProductRangeRepository(ServiceDbContext serviceDbContext)
        {
            this.serviceDbContext = serviceDbContext;
        }

        public ProductRange FindById(int key)
        {
            return this.serviceDbContext.ProductRanges
                .Where(b => b.Id == key)
                .ToList().First();
        }

        public IQueryable<ProductRange> FindAll()
        {
            return this.serviceDbContext.ProductRanges;
        }

        public void Add(ProductRange entity)
        {
            var nextId = this.serviceDbContext.ProductRanges.Max(t => t.Id) + 1;
            entity.Id = nextId;

            this.serviceDbContext.ProductRanges.Add(entity);
        }

        public void Remove(ProductRange entity)
        {
            throw new NotImplementedException();
        }

        public ProductRange FindBy(Expression<Func<ProductRange, bool>> expression)
        {
            return this.serviceDbContext.ProductRanges.Where(expression).ToList().FirstOrDefault();
        }

        public IQueryable<ProductRange> FilterBy(Expression<Func<ProductRange, bool>> expression)
        {
            return this.serviceDbContext.ProductRanges.Where(expression);
        }
    }
}