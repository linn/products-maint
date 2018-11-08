namespace Linn.Products.Domain.Linnapps.Repositories
{
    using System.Collections;
    using System.Collections.Generic;

    public interface ISACoreTypeRepository
    {
        SACoreType GetByCoreType(int coreType);

        IEnumerable<SACoreType> GetAll();

        void Add(SACoreType sACoreType);
    }
}