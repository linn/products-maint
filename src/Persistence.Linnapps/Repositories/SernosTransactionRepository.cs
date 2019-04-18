namespace Linn.Products.Persistence.Linnapps.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using Linn.Common.Persistence;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Proxy;

    public class SernosTransactionRepository : IRepository<SernosTransaction, string>
    {
        private readonly IDatabaseService linnappsDatabaseService;

        private readonly ServiceDbContext serviceDbContext;

        public SernosTransactionRepository(ServiceDbContext serviceDbContext, IDatabaseService linnappsDatabaseService)
        {
            this.serviceDbContext = serviceDbContext;
            this.linnappsDatabaseService = linnappsDatabaseService;
        }

        public SernosTransaction FindById(string key)
        {
            return this.serviceDbContext.SernosTranses.Where(s => s.TransCode == key).ToList().FirstOrDefault();
        }

        public IQueryable<SernosTransaction> FindAll()
        {
            return this.serviceDbContext.SernosTranses;
        }

        public void Add(SernosTransaction entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(SernosTransaction entity)
        {
            throw new NotImplementedException();
        }

        public SernosTransaction FindBy(Expression<Func<SernosTransaction, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IQueryable<SernosTransaction> FilterBy(Expression<Func<SernosTransaction, bool>> expression)
        {
            throw new NotImplementedException();
        }
    }
}
