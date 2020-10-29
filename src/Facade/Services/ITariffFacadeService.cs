namespace Linn.Products.Facade.Services
{
    using System.Collections.Generic;
    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Resources;

    public interface ITariffFacadeService : IFacadeService<Tariff, int, TariffResource, TariffResource>
    {
        IResult<ResponseModel<TariffsReallocator>> Reallocate(int oldTariffId, int newTariffId, IEnumerable<string> privileges);
    }
}
