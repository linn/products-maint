namespace Linn.Products.Domain.Linnapps.Repositories
{
    using System.Collections.Generic;

    using Linn.Common.Persistence;
    using Linn.Products.Domain.Linnapps.Products;

    public interface ITariffRepository : IRepository<Tariff, int>
    {
        IEnumerable<Tariff> SearchTariffs(string searchTerm);
    }
}