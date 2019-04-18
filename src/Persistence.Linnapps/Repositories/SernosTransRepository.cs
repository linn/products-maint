namespace Linn.Products.Persistence.Linnapps.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using Linn.Common.Persistence;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Proxy;

    public class SernosTransRepository : IRepository<SernosTrans, string>
    {
        private readonly IDatabaseService linnappsDatabaseService;

        private readonly ServiceDbContext serviceDbContext;

        public SernosTransRepository(ServiceDbContext serviceDbContext, IDatabaseService linnappsDatabaseService)
        {
            this.serviceDbContext = serviceDbContext;
            this.linnappsDatabaseService = linnappsDatabaseService;
        }

        public SernosTrans FindById(string key)
        {
            return this.serviceDbContext.SernosTranses.Where(s => s.TransCode == key).ToList().FirstOrDefault();
        }

        public IQueryable<SernosTrans> FindAll()
        {
            return this.serviceDbContext.SernosTranses;
        }

        public void Add(SernosTrans entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(SernosTrans entity)
        {
            throw new NotImplementedException();
        }

        public SernosTrans FindBy(Expression<Func<SernosTrans, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IQueryable<SernosTrans> FilterBy(Expression<Func<SernosTrans, bool>> expression)
        {
            throw new NotImplementedException();
        }
    }
}
