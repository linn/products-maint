namespace Linn.Products.Persistence.Linnapps.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using Linn.Common.Persistence;
    using Linn.Products.Domain.Linnapps.SalesPackages;

    using Microsoft.EntityFrameworkCore;

    public class SalesPackageRepository : IRepository<SalesPackage, int>
    {
        private readonly ServiceDbContext serviceDbContext;

        public SalesPackageRepository(ServiceDbContext serviceDbContext)
        {
            this.serviceDbContext = serviceDbContext;
        }

        public SalesPackage FindById(int key)
        {
            return this.serviceDbContext.SalesPackages
                .Where(b => b.Id == key)
                .Include(a => a.Elements)
                .ThenInclude(b => b.SalesPackageElement)
                .ToList().First();
        }

        public IQueryable<SalesPackage> FindAll()
        {
            return this.serviceDbContext.SalesPackages
                .Include(a => a.Elements)
                .ThenInclude(b => b.SalesPackageElement);
        }

        public void Add(SalesPackage entity)
        {
            this.serviceDbContext.SalesPackages.Add(entity);
        }

        public void Remove(SalesPackage entity)
        {
            throw new NotImplementedException();
        }

        public SalesPackage FindBy(Expression<Func<SalesPackage, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IQueryable<SalesPackage> FilterBy(Expression<Func<SalesPackage, bool>> expression)
        {
            throw new NotImplementedException();
        }
    }
}