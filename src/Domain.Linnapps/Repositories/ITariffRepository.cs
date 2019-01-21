namespace Linn.Products.Domain.Linnapps.Repositories
{
    using System.Collections.Generic;
    using Products;

    public interface ITariffRepository
    {
        IEnumerable<Tariff> SearchTariffs(string searchTerm);

        Tariff FindById(int id);

        void Add(Tariff tariff);
    }
}