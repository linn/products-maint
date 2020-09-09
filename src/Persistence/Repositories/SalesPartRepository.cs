namespace Linn.Products.Persistence.Repositories
{
    using Linn.Common.Persistence;
    using Linn.Products.Domain.Products;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public class ProductSalesPartRepository : IRepository<ProductSalesPart, int>
    {
        private readonly ProductsServiceDbContext serviceDbContext;

        public ProductSalesPartRepository(ProductsServiceDbContext serviceDbContext)
        {
            this.serviceDbContext = serviceDbContext;
        }

        public ProductSalesPart FindById(int key)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ProductSalesPart> FindAll()
        {
            return this.serviceDbContext.SalesParts;
        }

        public void Add(ProductSalesPart entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(ProductSalesPart entity)
        {
            throw new NotImplementedException();
        }

        public ProductSalesPart FindBy(Expression<Func<ProductSalesPart, bool>> expression)
        {
            return this.serviceDbContext.SalesParts.Where(expression).ToList().FirstOrDefault();
        }

        public IQueryable<ProductSalesPart> FilterBy(Expression<Func<ProductSalesPart, bool>> expression)
        {
            return this.serviceDbContext.SalesParts.Where(expression).Include(a => a.Tariff)
                .Include(x => x.RootProduct)
                .Include(x => x.Cit)
                .Include(x => x.Carton)
                .Include(x => x.Labels)
                .Include(x => x.ReplacedByPart)
                .Include(x => x.OrderType)
                .Include(x => x.TypeOfSerialNumber)
                .Include(x => x.SerialNumberSource)
                .Include(x => x.TypeOfSale);
        }
    }
}
