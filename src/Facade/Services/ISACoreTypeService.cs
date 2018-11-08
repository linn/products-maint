
namespace Linn.Products.Facade.Services
{
    using System.Collections.Generic;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    public interface ISACoreTypeService
    {
        IResult<SACoreType> GetSACoreType(int coreType);

        IResult<IEnumerable<SACoreType>> GetAllSACoreTypes();

        IResult<SACoreType> AddSACoreType(SACoreTypeResource resource);

        IResult<SACoreType> UpdateSACoreType(int coreType, SACoreTypeResource resource);
    }
}
