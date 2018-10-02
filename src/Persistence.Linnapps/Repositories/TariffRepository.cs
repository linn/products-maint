namespace Linn.Products.Persistence.Linnapps.Repositories
{
    using System.Collections.Generic;
    using Domain.Linnapps.Products;
    using Domain.Repositories;

    public class TariffRepository : ITariffRepository
    {
        private readonly ServiceDbContext serviceDbContext;

        public TariffRepository(ServiceDbContext serviceDbContext)
        {
            this.serviceDbContext = serviceDbContext;
        }

        public IEnumerable<Tariff> SearchTariffs(string searchTerm)
        {
            return this.serviceDbContext.Tariffs;
        }

        public Tariff GetTariffById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
