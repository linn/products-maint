namespace Linn.Products.Facade.Services
{
    using System.Collections.Generic;

    using Linn.Common.Domain.Exceptions;
    using Linn.Common.Facade;
    using Linn.Common.Persistence;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;
    
    public class SernosNoteService : ISernosNoteService
    {
        private readonly IRepository<SernosNote, int> repository;
        private readonly ITransactionManager transactionManager;

        public SernosNoteService(
            IRepository<SernosNote, int> repository, 
            ITransactionManager transactionManager)
        {
            this.repository = repository;
            this.transactionManager = transactionManager;
        }

        public IResult<SernosNote> GetSernosNoteById(int sernosNoteId)
        {
            var sernosNote = this.repository.FindById(sernosNoteId);
            if (sernosNote == null)
            {
                return new NotFoundResult<SernosNote>();
            }

            return new SuccessResult<SernosNote>(sernosNote);
        }

        public IResult<SernosNote> GetSernosNote(string sernosGroup, int? sernosNumber, string transCode)
        {
            if (!this.ValidateQuery(sernosGroup, sernosNumber, transCode))
            {
                return new BadRequestResult<SernosNote>("Invalid search parameters");
            }

            var sernosNote = this.repository.FindBy(
                s => s.SernosGroup == sernosGroup && s.SernosNumber == sernosNumber && s.TransCode == transCode);

            if (sernosNote == null)
            {
                return new NotFoundResult<SernosNote>();
            }

            return new SuccessResult<SernosNote>(sernosNote);
        }

        public IResult<SernosNote> Add(SernosNoteCreateResource resource)
        {
            try
            {
                var sernosNote = new SernosNote(resource.SernosNotes)
                                     {
                                         SernosGroup = resource.SernosGroup,
                                         SernosNumber = resource.SernosNumber,                                         
                                         SernosTRef = resource.SernosTRef,
                                         TransCode = resource.TransCode
                                     };

                this.repository.Add(sernosNote);
                this.transactionManager.Commit();

                return new CreatedResult<SernosNote>(sernosNote);
            }
            catch (DomainException exception)
            {
                return new BadRequestResult<SernosNote>(exception.Message);
            }
        }

        public IResult<SernosNote> Update(int sernosNoteId, SernosNoteResource resource)
        {
            var sernosNote = this.repository.FindById(sernosNoteId);
            if (sernosNote == null)
            {
                return new NotFoundResult<SernosNote>();
            }

            try
            {
                sernosNote.Update(
                    resource.SernosNotes,
                    resource.SernosGroup,
                    resource.SernosNumber,
                    resource.SernosTRef,
                    resource.TransCode);

                this.transactionManager.Commit();
            }
            catch (DomainException exception)
            {
                return new BadRequestResult<SernosNote>(exception.Message);
            }

            return new SuccessResult<SernosNote>(sernosNote);
        }

        private bool ValidateQuery(string sernosGroup, int? sernosNumber, string transCode)
        {
            return !string.IsNullOrEmpty(sernosGroup) && !string.IsNullOrEmpty(transCode) && sernosNumber.HasValue;
        }
    }
}