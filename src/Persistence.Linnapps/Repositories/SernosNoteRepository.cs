namespace Linn.Products.Persistence.Linnapps.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using Linn.Common.Persistence;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Proxy;

    public class SernosNoteRepository : IRepository<SernosNote, int>
    {
        private readonly IDatabaseService linnappsDatabaseService;

        private readonly ServiceDbContext serviceDbContext;

        public SernosNoteRepository(ServiceDbContext serviceDbContext, IDatabaseService linnappsDatabaseService)
        {
            this.serviceDbContext = serviceDbContext;
            this.linnappsDatabaseService = linnappsDatabaseService;
        }

        public SernosNote FindById(int key)
        {
            return this.serviceDbContext.SernosNotes    
                .Where(n => n.SernosNoteId == key)
                .ToList()
                .FirstOrDefault();
        }

        public IQueryable<SernosNote> FindAll()
        {
            return this.serviceDbContext.SernosNotes;
        }

        public void Add(SernosNote entity)
        {
            entity.SernosNoteId = this.linnappsDatabaseService.GetIdSequence("TODO find sequence name");
            this.serviceDbContext.SernosNotes.Add(entity);
        }

        public IQueryable<SernosNote> FilterBy(Expression<Func<SernosNote, bool>> expression)
        {
            return this.serviceDbContext.SernosNotes.Where(expression);
        }

        public SernosNote FindBy(Expression<Func<SernosNote, bool>> expression)
        {
            return this.serviceDbContext.SernosNotes.Where(expression).ToList().FirstOrDefault();
        }

        public void Remove(SernosNote entity)
        {
            throw new NotImplementedException();
        }
    }
}