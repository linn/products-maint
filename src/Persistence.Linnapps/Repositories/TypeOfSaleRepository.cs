namespace Linn.Products.Persistence.Linnapps.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using Linn.Common.Persistence;
    using Linn.Products.Domain.Linnapps;

    public class TypeOfSaleRepository : IRepository<TypeOfSale, string>
    {
        private readonly ServiceDbContext serviceDbContext;

        public TypeOfSaleRepository(ServiceDbContext serviceDbContext)
        {
            this.serviceDbContext = serviceDbContext;
        }

        public TypeOfSale FindById(string key)
        {
            return this.serviceDbContext.TypesOfSale.Where(b => b.Name == key).ToList().First();
        }

        public IQueryable<TypeOfSale> FindAll()
        {
            return this.serviceDbContext.TypesOfSale;
        }

        public void Add(TypeOfSale typeOfSale)
        {
            this.serviceDbContext.TypesOfSale.Add(typeOfSale);
        }

        public void Remove(TypeOfSale entity)
        {
            throw new NotImplementedException();
        }

        public TypeOfSale FindBy(Expression<Func<TypeOfSale, bool>> expression)
        {
            return this.serviceDbContext.TypesOfSale.Where(expression).ToList().FirstOrDefault();
        }

        public IQueryable<TypeOfSale> FilterBy(Expression<Func<TypeOfSale, bool>> expression)
        {
            return this.serviceDbContext.TypesOfSale.Where(expression);
        }
    }
}
