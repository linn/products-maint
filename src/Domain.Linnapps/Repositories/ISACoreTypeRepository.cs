namespace Linn.Products.Domain.Linnapps.Repositories
{
    using System.Collections;
    using System.Collections.Generic;

    public interface ISACoreTypeRepository
    {
        SaCoreType GetByCoreType(int coreType);

        IEnumerable<SaCoreType> GetAll();

        void Add(SaCoreType sACoreType);
    }
}