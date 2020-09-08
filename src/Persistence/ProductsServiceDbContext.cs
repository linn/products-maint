namespace Linn.Products.Persistence
{
    using Linn.Common.Configuration;
    using Linn.Products.Domain;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Domain.Linnapps.SalesPackages;
    using Linn.Products.Domain.Linnapps.SernosTransactions;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;

    public class ProductsServiceDbContext : DbContext
    {
        public static readonly LoggerFactory MyLoggerFactory =
            new LoggerFactory(new[] { new Microsoft.Extensions.Logging.Debug.DebugLoggerProvider() });

        public DbSet<SalesPart> SalesParts { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            this.BuildSalesParts(builder);
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var host = ConfigurationManager.Configuration["DATABASE_2_HOST"];
            var userId = ConfigurationManager.Configuration["DATABASE_2_USER_ID"];
            var password = ConfigurationManager.Configuration["DATABASE_2_PASSWORD"];
            var serviceId = ConfigurationManager.Configuration["DATABASE_2_NAME"];

            var dataSource =
                $"(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST={host})(PORT=1521))(CONNECT_DATA=(SERVICE_NAME={serviceId})(SERVER=dedicated)))";

            optionsBuilder.UseOracle($"Data Source={dataSource};User Id={userId};Password={password};");
            optionsBuilder.UseLoggerFactory(MyLoggerFactory);
            optionsBuilder.EnableSensitiveDataLogging(true);
            base.OnConfiguring(optionsBuilder);
        }
        

        private void BuildSalesParts(ModelBuilder builder)
        {
            builder.Entity<SalesArticle>().ToTable("SALES_PARTS");
            builder.Entity<SalesPart>().HasKey(t => t.Id);
            builder.Entity<SalesPart>().Property(t => t.Id).HasColumnName("ID")
                .HasMaxLength(10);
            builder.Entity<SalesPart>().Property(t => t.TariffId).HasColumnName("TARIFF_ID").HasMaxLength(10);
            builder.Entity<SalesPart>().Property(t => t.Description).HasColumnName("DESCRIPTION").HasMaxLength(100);
        }
    }
}