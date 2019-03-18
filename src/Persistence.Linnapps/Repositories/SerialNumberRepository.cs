namespace Linn.Products.Persistence.Linnapps.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using Linn.Common.Persistence;
    using Linn.Products.Domain.Linnapps;

    using Microsoft.EntityFrameworkCore;

    public class SerialNumberRepository : IRepository<SerialNumber, int>
    {
        private readonly ServiceDbContext serviceDbContext;

        public SerialNumberRepository(ServiceDbContext serviceDbContext)
        {
            this.serviceDbContext = serviceDbContext;
        }

        public SerialNumber FindById(int key)
        {
            return this.serviceDbContext.SerialNumbers
                .Where(a => a.SernosTref == key)
                .Include(a => a.SalesArticle)
                .ToList()
                .First();
        }

        public IQueryable<SerialNumber> FindAll()
        {
            throw new NotImplementedException();
        }

        public void Add(SerialNumber entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(SerialNumber entity)
        {
            throw new NotImplementedException();
        }

        public SerialNumber FindBy(Expression<Func<SerialNumber, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IQueryable<SerialNumber> FilterBy(Expression<Func<SerialNumber, bool>> expression)
        {
            // TODO get a resource builder for multiple sernos
            // copy the filterby over there ->
            // get these back then figure out from dbcontext how to get the note with it
            // think that'll be a join?
            return this.serviceDbContext.SerialNumbers.Where(expression);
        }
    }
}
