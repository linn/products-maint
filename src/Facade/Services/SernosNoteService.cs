namespace Linn.Products.Facade.Services
{
    using System;
    using System.Linq.Expressions;

    using Linn.Common.Facade;
    using Linn.Common.Persistence;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    public class SernosNoteService : FacadeService<SernosNote, int, SernosNoteCreateResource, SernosNoteResource>
    {
        public SernosNoteService(IRepository<SernosNote, int> repository, ITransactionManager transactionManager)
            : base(repository, transactionManager)
        {
        }

        protected override SernosNote CreateFromResource(SernosNoteCreateResource resource)
        {
            var sernosNote = new SernosNote(resource.SernosNotes)
                                 {
                                     SernosGroup = resource.SernosGroup,
                                     SernosNumber = resource.SernosNumber,
                                     SernosTRef = resource.SernosTRef,
                                     TransCode = resource.TransCode
                                 };

            return sernosNote;
        }

        protected override void UpdateFromResource(SernosNote sernosNote, SernosNoteResource resource)
        {
            sernosNote.Update(
                resource.SernosNotes,
                resource.SernosGroup,
                resource.SernosNumber,
                resource.SernosTRef,
                resource.TransCode);
        }

        protected override Expression<Func<SernosNote, bool>> SearchExpression(string searchTerm)
        {
            return s => s.SernosNumber.ToString().Equals(searchTerm);
        }
    }
}