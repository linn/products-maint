namespace Linn.Products.Persistence.Linnapps.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using Linn.Common.Persistence;
    using Linn.Products.Domain.Linnapps.SernosTransactions;

    public class SernosCountRepository : IRepository<SernosCount, string>
    {
        private readonly ServiceDbContext serviceDbContext;

        public SernosCountRepository(ServiceDbContext serviceDbContext)
        {
            this.serviceDbContext = serviceDbContext;
        }

        public SernosCount FindById(string key)
        {
            return this.serviceDbContext.SerialNumberTransactionCountTypes
                .Where(a => a.Name == key)
                .ToList().FirstOrDefault();
        }

        public IQueryable<SernosCount> FindAll()
        {
            return this.serviceDbContext.SerialNumberTransactionCountTypes;
        }

        public void Add(SernosCount sernosCount)
        {
            this.serviceDbContext.SerialNumberTransactionCountTypes.Add(sernosCount);
        }

        public void Remove(SernosCount entity)
        {
            throw new NotImplementedException();
        }

        public SernosCount FindBy(Expression<Func<SernosCount, bool>> expression)
        {
            return this.serviceDbContext.SerialNumberTransactionCountTypes
                .Where(expression)
                .FirstOrDefault();
        }

        public IQueryable<SernosCount> FilterBy(Expression<Func<SernosCount, bool>> expression)
        {
            return this.serviceDbContext.SerialNumberTransactionCountTypes.Where(expression);
        }
    }
}