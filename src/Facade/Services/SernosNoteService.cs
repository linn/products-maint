namespace Linn.Products.Facade.Services
{
    using Linn.Common.Facade;
    using Linn.Common.Persistence;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    public class SernosNoteService : FacadeService<SernosNote, int, SernosNoteResource, SernosNoteResource>
    {
        public SernosNoteService(
            IRepository<SernosNote, int> repository, 
            ITransactionManager transactionManager)
            : base(repository, transactionManager)
        {
        }

        protected override SernosNote CreateFromResource(SernosNoteResource resource)
        {
            // TODO check that ID is working 
            var sernosNote = new SernosNote(resource.SernosNotes)
                                 {
                                     SernosGroup = resource.SernosGroup,
                                     SernosNumber = resource.SernosNumber,
//                                     SernosTRef = resource.SernosTRef,
                                     TransCode = resource.TransCode
                                 };

            return sernosNote;
        }

        protected override void UpdateFromResource(SernosNote sernosNote, SernosNoteResource updateResource)
        {
            sernosNote.Update(
                updateResource.SernosNotes,
                updateResource.SernosGroup,
                updateResource.SernosNumber,
                updateResource.SernosTref,
                updateResource.TransCode);
        }
    }
}