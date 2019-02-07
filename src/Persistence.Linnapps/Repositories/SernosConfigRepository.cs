namespace Linn.Products.Persistence.Linnapps.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using Linn.Common.Persistence;
    using Linn.Products.Domain.Linnapps;

    public class SernosConfigRepository : IRepository<SernosConfig, string>
    {
        private readonly ServiceDbContext serviceDbContext;

        public SernosConfigRepository(ServiceDbContext serviceDbContext)
        {
            this.serviceDbContext = serviceDbContext;
        }

        public SernosConfig FindById(string key)
        {
            return this.serviceDbContext.SernosConfigs.Where(a => a.Name == key).ToList().First();
        }

        public IQueryable<SernosConfig> FindAll()
        {
            return this.serviceDbContext.SernosConfigs;
        }

        public void Add(SernosConfig sernosConfig)
        {
            this.serviceDbContext.SernosConfigs.Add(sernosConfig);
            this.serviceDbContext.SaveChanges();
        }

        public void Remove(SernosConfig entity)
        {
            throw new NotImplementedException();
        }

        public SernosConfig FindBy(Expression<Func<SernosConfig, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IQueryable<SernosConfig> FilterBy(Expression<Func<SernosConfig, bool>> expression)
        {
            throw new NotImplementedException();
        }
    }
}