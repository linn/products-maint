namespace Linn.Products.Facade.Services
{
    using System.Collections.Generic;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    public interface ISerialNumberService
    {
        IResult<SerialNumber> GetByTRef(int sernosTRef);

        IResult<IEnumerable<SerialNumber>> GetBySernosNumber(int sernosNumber);

        IResult<SerialNumber> Add(SerialNumberResource resource);

        IResult<SerialNumber> Update(int sernosTRef, SerialNumberResource resource);
    }
}
