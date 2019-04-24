namespace Linn.Products.Persistence.Linnapps.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using Linn.Common.Persistence;
    using Linn.Products.Domain.Linnapps.SernosTransactions;

    public class SernosTransRepository : IRepository<SernosTrans, string>
    {
        private readonly ServiceDbContext serviceDbContext;

        public SernosTransRepository(ServiceDbContext serviceDbContext)
        {
            this.serviceDbContext = serviceDbContext;
        }

        public SernosTrans FindById(string key)
        {
            return this.serviceDbContext.SerialNumberTransactionTypes
                .Where(a => a.TransCode == key).ToList().FirstOrDefault();
        }

        public IQueryable<SernosTrans> FindAll()
        {
            return this.serviceDbContext.SerialNumberTransactionTypes;
        }

        public void Add(SernosTrans sernosTrans)
        {
            this.serviceDbContext.SerialNumberTransactionTypes.Add(sernosTrans);
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