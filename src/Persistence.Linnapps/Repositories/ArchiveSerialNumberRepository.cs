namespace Linn.Products.Persistence.Linnapps.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using Linn.Common.Persistence;
    using Linn.Products.Domain.Linnapps;

    public class ArchiveSerialNumberRepository : IRepository<ArchiveSerialNumber, int>
    {
        private readonly ServiceDbContext serviceDbContext;

        public ArchiveSerialNumberRepository(ServiceDbContext serviceDbContext)
        {
            this.serviceDbContext = serviceDbContext;
        }

        public ArchiveSerialNumber FindById(int key)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ArchiveSerialNumber> FindAll()
        {
            throw new NotImplementedException();
        }

        public void Add(ArchiveSerialNumber entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(ArchiveSerialNumber entity)
        {
            throw new NotImplementedException();
        }

        public ArchiveSerialNumber FindBy(Expression<Func<ArchiveSerialNumber, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ArchiveSerialNumber> FilterBy(Expression<Func<ArchiveSerialNumber, bool>> expression)
        {
            return this.serviceDbContext.ArchiveSerialNumbers.Where(expression);
        }
    }
}
