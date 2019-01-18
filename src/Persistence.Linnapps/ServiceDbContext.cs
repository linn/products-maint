namespace Linn.Products.Persistence.Linnapps
{
    using System.Collections.Generic;

    using Domain.Linnapps.Products;

    using Linn.Common.Configuration;
    using Linn.Products.Domain.Linnapps;

    using Oracle.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class ServiceDbContext : DbContext 
    {
        public ServiceDbContext()
        {
            this.InitialiseTariffs();
        }

        public DbSet<SaCoreType> SaCoreTypes { get; set; }

        public DbSet<SernosConfig> SernosConfigs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var host = ConfigurationManager.Configuration["DATABASE_HOST"];
            var userId = ConfigurationManager.Configuration["DATABASE_USER_ID"];
            var password = ConfigurationManager.Configuration["DATABASE_PASSWORD"];
            var serviceId = ConfigurationManager.Configuration["DATABASE_NAME"];
            optionsBuilder.UseOracle($"User Id={userId};Password={password}; Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST={host})(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME={serviceId})));"); 
            base.OnConfiguring(optionsBuilder);
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
