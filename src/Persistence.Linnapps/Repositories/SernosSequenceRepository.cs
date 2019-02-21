namespace Linn.Products.Persistence.Linnapps.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using Linn.Common.Persistence;
    using Linn.Products.Domain.Linnapps;

    public class SernosSequenceRepository : IRepository<SernosSequence, string>
    {
        private readonly ServiceDbContext serviceDbContext;

        public SernosSequenceRepository(ServiceDbContext serviceDbContext)
        {
            this.serviceDbContext = serviceDbContext;
        }

        public SernosSequence FindById(string key)
        {
            return this.serviceDbContext.SernosSequences.Where(s => s.SequenceName == key).ToList().First();
        }

        public IQueryable<SernosSequence> FindAll()
        {
            return this.serviceDbContext.SernosSequences;
        }

        public void Add(SernosSequence sernosSequence)
        {
            this.serviceDbContext.SernosSequences.Add(sernosSequence);
            this.serviceDbContext.SaveChanges();
        }

        public void Remove(SernosSequence entity)
        {
            throw new NotImplementedException();
        }

        public SernosSequence FindBy(Expression<Func<SernosSequence, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IQueryable<SernosSequence> FilterBy(Expression<Func<SernosSequence, bool>> expression)
        {
            throw new NotImplementedException();
        }
    }
}
