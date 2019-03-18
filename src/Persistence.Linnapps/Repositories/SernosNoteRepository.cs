namespace Linn.Products.Persistence.Linnapps.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using Linn.Common.Persistence;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Proxy;

    using Microsoft.EntityFrameworkCore;

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
                .Include(s => s.SerialNumber)
//                .ThenInclude(n => n.SalesArticle)
                .ToList().First();
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
            throw new NotImplementedException();
        }

        public SernosNote FindBy(Expression<Func<SernosNote, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void Remove(SernosNote entity)
        {
            throw new NotImplementedException();
        }
    }
}