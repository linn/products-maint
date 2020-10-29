namespace Linn.Products.Domain.Repositories
{
    using Linn.Products.Domain.Linnapps;
    using System.Collections.Generic;

    public interface ISalesPartRepository
    {
        IEnumerable<SalesPart> GetWEEESalesParts();

        TariffsReallocator ReallocateSalesParts(int oldTariff, int NewTariff);
    }
}
