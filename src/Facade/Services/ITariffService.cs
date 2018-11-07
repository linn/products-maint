namespace Linn.Products.Facade.Services
{
    using System.Collections.Generic;
    using Common.Facade;
    using Domain.Linnapps.Products;
    using Resources;

    public interface ITariffService
    {
        IResult<IEnumerable<Tariff>> GetTariffs(string searchTerm);

        IResult<Tariff> GetTariff(int id);

        IResult<Tariff> AddTariff(TariffResource resource);

        IResult<Tariff> UpdateTariff(int id, TariffResource resource);
    }
}