namespace Linn.Products.Persistence.Linnapps
{
    using System.Collections.Generic;
    using Domain.Linnapps.Products;

    public class ServiceDbContext
    {
        public ServiceDbContext()
        {
            this.InitialiseTariffs();        
        }

        public List<Tariff> Tariffs { get; set; }

        private void InitialiseTariffs()
        {
            this.Tariffs = new List<Tariff>();
            this.Tariffs.Add(new Tariff()
            {
                Id = 1,
                TariffCode = "8518 9000 99",
                USTariffCode = "8518.90.3000",
                Description = "Parts and accessories for loudspeakers and amplifiers"
            });
            this.Tariffs.Add(new Tariff()
            {
                Id = 2,
                TariffCode = "8518 2200 90",
                USTariffCode = "8518.22.0000",
                Description = "Multiple loudspeakers mounted in the same enclosure"
            });
            this.Tariffs.Add(new Tariff()
            {
                Id = 3,
                TariffCode = "8523493900",
                Duty = 3.5m,
                Description = "Multiple loudspeakers mounted in the same enclosure"
            });
        }
    }
}
