namespace Linn.Products.Facade.Services
{
    using System.Collections.Generic;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    public interface IArchiveSerialNumberFacadeService : IFacadeService<ArchiveSerialNumber, int, ArchiveSerialNumberResource, ArchiveSerialNumberResource>
    {
        IResult<ResponseModel<IEnumerable<ArchiveSerialNumber>>> SearchByDocumentNumber(int documentNumber, IEnumerable<string> privileges);
    }
}