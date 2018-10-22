﻿namespace Linn.Products.Persistence.Linnapps.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
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
            if (string.IsNullOrEmpty(searchTerm))
            {
                return this.serviceDbContext.Tariffs;
            }

            return this.serviceDbContext.Tariffs.Where(t =>
                t.TariffCode.Contains(searchTerm) || t.Description.ToLower().Contains(searchTerm.ToLower()));
        }

        public Tariff GetTariffById(int id)
        {
            return this.serviceDbContext.Tariffs.SingleOrDefault(t => t.Id == id);
        }
    }
}
