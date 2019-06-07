namespace Linn.Products.Facade.Services
{
    using System.Collections.Generic;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    public interface ISerialNumberFacadeService : IFacadeService<SerialNumber, int, SerialNumberCreateResource, SerialNumberResource>
    {
        IResult<ResponseModel<IEnumerable<SerialNumber>>> CreateSerialNumbers(SerialNumberCreateResource resource, IEnumerable<string> privileges);
    }
}
