namespace Linn.Products.Domain.Repositories
{
    using System.Collections.Generic;
    using Linnapps.Products;

    public interface ITariffRepository
    {
        IEnumerable<Tariff> SearchTariffs(string searchTerm);

        Tariff GetTariffById(int id);

        void Add(Tariff tariff);
    }
}