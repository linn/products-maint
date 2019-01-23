namespace Linn.Products.Persistence.Linnapps
{
    using Linn.Common.Configuration;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Domain.Linnapps.Products;

    using Microsoft.EntityFrameworkCore;

    public class ServiceDbContext : DbContext
    {
        public DbSet<SaCoreType> SaCoreTypes { get; set; }

        public DbSet<SernosConfig> SernosConfigs { get; set; }

        public DbSet<Tariff> Tariffs { get; set; }

        public DbSet<SalesArticle> SalesArticles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            this.BuildSaCoreType(builder);
            this.BuildSernosConfig(builder);
            this.BuildTariffs(builder);
            this.BuildSalesArticles(builder);

            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var host = ConfigurationManager.Configuration["DATABASE_HOST"];
            var userId = ConfigurationManager.Configuration["DATABASE_USER_ID"];
            var password = ConfigurationManager.Configuration["DATABASE_PASSWORD"];
            var serviceId = ConfigurationManager.Configuration["DATABASE_NAME"];
            optionsBuilder.UseOracle($"User Id={userId};Password={password}; Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST={host}.linn.co.uk)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME={serviceId})));");
            base.OnConfiguring(optionsBuilder);
        }

        private void BuildSaCoreType(ModelBuilder builder)
        {
            builder.Entity<SaCoreType>().ToTable("SA_CORE_TYPES");
            builder.Entity<SaCoreType>().HasKey(t => t.CoreType);
            builder.Entity<SaCoreType>().Property(t => t.CoreType).HasColumnName("CORE_TYPE");
            builder.Entity<SaCoreType>().Property(t => t.TriggerLevel).HasColumnName("TRIGGER_LEVEL");
            builder.Entity<SaCoreType>().Property(t => t.Description).HasColumnName("DESCRIPTION");
            builder.Entity<SaCoreType>().Property(t => t.DateInvalid).HasColumnName("DATE_INVALID");
            builder.Entity<SaCoreType>().Property(t => t.LookAheadDays).HasColumnName("LOOKAHEAD_DAYS");
            builder.Entity<SaCoreType>().Property(t => t.SortOrder).HasColumnName("SORT_ORDER");
        }

        private void BuildSernosConfig(ModelBuilder builder)
        {
            builder.Entity<SernosConfig>().ToTable("SERNOS_CONFIG");
            builder.Entity<SernosConfig>().HasKey(t => t.Name);
            builder.Entity<SernosConfig>().Property(t => t.Name).HasColumnName("NAME");
            builder.Entity<SernosConfig>().Property(t => t.Description).HasColumnName("DESCRIPTION");
            builder.Entity<SernosConfig>().Property(t => t.SerialNumbered).HasColumnName("SERIAL_NUMBERED");
            builder.Entity<SernosConfig>().Property(t => t.NumberOfSernos).HasColumnName("NUM_OF_SERNOS");
            builder.Entity<SernosConfig>().Property(t => t.NumberOfBoxes).HasColumnName("NUM_OF_BOXES");
            builder.Entity<SernosConfig>().Property(t => t.StartOn).HasColumnName("START_ON");
        }

        private void BuildTariffs(ModelBuilder builder)
        {
            builder.Entity<Tariff>().ToTable("TARIFFS");
            builder.Entity<Tariff>().HasKey(t => t.Id);
            builder.Entity<Tariff>().Property(t => t.Id).HasColumnName("TARIFF_ID");
            builder.Entity<Tariff>().Property(t => t.TariffCode).HasColumnName("TARIFF_CODE").HasMaxLength(14);
            builder.Entity<Tariff>().Property(t => t.Description).HasColumnName("DESCRIPTION");
            builder.Entity<Tariff>().Property(t => t.DateInvalid).HasColumnName("DATE_INVALID");
            builder.Entity<Tariff>().Property(t => t.Duty).HasColumnName("DUTY");
            builder.Entity<Tariff>().Property(t => t.USTariffCode).HasColumnName("US_TARIFF_CODE").HasMaxLength(14);
        }

        private void BuildSalesArticles(ModelBuilder builder)
        {
            builder.Entity<SalesArticle>().ToTable("SALES_ARTICLES");
            builder.Entity<SalesArticle>().HasKey(t => t.ArticleNumber);
            builder.Entity<SalesArticle>().Property(t => t.ArticleNumber).HasColumnName("ARTICLE_NUMBER").HasMaxLength(14);
            builder.Entity<SalesArticle>().Property(t => t.InvoiceDescription).HasColumnName("INVOICE_DESCRIPTION").HasMaxLength(100);
            builder.Entity<SalesArticle>().Property(t => t.CartonType).HasColumnName("CARTON_TYPE").HasMaxLength(10);
            builder.Entity<SalesArticle>().Property(t => t.EanCode).HasColumnName("EAN_CODE").HasMaxLength(13);
            builder.Entity<SalesArticle>().Property(t => t.PackingDescription).HasColumnName("PACKING_DESCRIPTION").HasMaxLength(50);
            builder.Entity<SalesArticle>().Property(t => t.SaDiscountFamily).HasColumnName("SA_DISCOUNT_FAMILY").HasMaxLength(10);
            builder.Entity<SalesArticle>().Property(t => t.TypeOfSale).HasColumnName("TYPE_OF_SALE").HasMaxLength(10);
            builder.Entity<SalesArticle>().Property(t => t.ForecastType).HasColumnName("FORECAST_TYPE").HasMaxLength(4);
            builder.Entity<SalesArticle>().Property(t => t.ForecastFromDate).HasColumnName("FORECAST_FROM_DATE");
            builder.Entity<SalesArticle>().Property(t => t.ForecastToDate).HasColumnName("FORECAST_TO_DATE");
            builder.Entity<SalesArticle>().Property(t => t.PhaseInDate).HasColumnName("PHASE_IN_DATE");
            builder.Entity<SalesArticle>().Property(t => t.PhaseOutDate).HasColumnName("PHASE_OUT_DATE");
            builder.Entity<SalesArticle>().Property(t => t.PercentageOfRootProductSales).HasColumnName("PERCENTAGE_SALES");
        }
    }
}
