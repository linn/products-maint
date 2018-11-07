namespace Linn.Products.Facade.Services
{
    using System.Collections.Generic;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Resources;

    public interface ITariffService
    {
        IResult<IEnumerable<Tariff>> GetTariffs(string searchTerm);

        IResult<Tariff> GetTariff(int id);

        IResult<Tariff> AddTariff(TariffResource resource);

        IResult<Tariff> UpdateTariff(int id, TariffResource resource);
    }
}