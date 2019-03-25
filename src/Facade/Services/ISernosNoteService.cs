namespace Linn.Products.Facade.Services
{
    using System.Collections.Generic;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    public interface ISernosNoteService
    {
        IResult<SernosNote> GetSernosNoteById(int sernosNoteId);

        IResult<SernosNote> GetSernosNote(string sernosGroup, int? sernosNumber, string transCode);

        IResult<SernosNote> Add(SernosNoteCreateResource resource);

        IResult<SernosNote> Update(int sernosNoteId, SernosNoteResource resource);
    }
}
