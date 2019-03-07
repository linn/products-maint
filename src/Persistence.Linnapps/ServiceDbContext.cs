namespace Linn.Products.Persistence.Linnapps
{
    using Linn.Common.Configuration;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Domain.Linnapps.Products;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Debug;

    public class ServiceDbContext : DbContext
    {
        public DbSet<SaCoreType> SaCoreTypes { get; set; }

        public DbSet<SernosConfig> SernosConfigs { get; set; }

        public DbSet<Tariff> Tariffs { get; set; }

        public DbSet<SalesArticle> SalesArticles { get; set; }

        public DbSet<TypeOfSale> TypesOfSale { get; set; }

        public DbSet<CartonType> CartonTypes { get; set; }

        public DbSet<SaHoldStory> SaHoldStories { get; set; }

        public DbSet<VatCode> VatCodes { get; set; }

        public DbSet<ProductRange> ProductRanges { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public static readonly Microsoft.Extensions.Logging.LoggerFactory _myLoggerFactory =
            new LoggerFactory(new[] {
                                            new Microsoft.Extensions.Logging.Debug.DebugLoggerProvider()
                                        });

        protected override void OnModelCreating(ModelBuilder builder)
        {
            this.BuildSaCoreType(builder);
            this.BuildSernosConfig(builder);
            this.BuildTariffs(builder);
            this.BuildSalesArticles(builder);
            this.BuildTypesOfSale(builder);
            this.BuildCartonTypes(builder);
            this.BuildSaHoldStories(builder);
            this.BuildVatCode(builder);
            this.BuildProductRanges(builder);
            this.BuildEmployees(builder);
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var host = ConfigurationManager.Configuration["DATABASE_HOST"];
            var userId = ConfigurationManager.Configuration["DATABASE_USER_ID"];
            var password = ConfigurationManager.Configuration["DATABASE_PASSWORD"];
            var serviceId = ConfigurationManager.Configuration["DATABASE_NAME"];

            var dataSource =
                $"(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST={host})(PORT=1521))(CONNECT_DATA=(SERVICE_NAME={serviceId})(SERVER=dedicated)))";

            optionsBuilder.UseOracle($"Data Source={dataSource};User Id={userId};Password={password};");
            optionsBuilder.UseLoggerFactory(_myLoggerFactory);



            base.OnConfiguring(optionsBuilder);
        }

        private void BuildProductRanges(ModelBuilder builder)
        {
            builder.Entity<ProductRange>().ToTable("PRODUCT_RANGES");
            builder.Entity<ProductRange>().HasKey(r => r.Id);
            builder.Entity<ProductRange>().Property(r => r.Id).HasColumnName("BRIDGE_ID");
            builder.Entity<ProductRange>().Property(r => r.RangeName).HasColumnName("RANGE_NAME").HasMaxLength(30);
            builder.Entity<ProductRange>().Property(r => r.RangeDescription).HasColumnName("RANGE_DESCRIPTION")
                .HasMaxLength(150);
            builder.Entity<ProductRange>().Property(r => r.DateInvalid).HasColumnName("DATE_INVALID");
        }

        private void BuildCartonTypes(ModelBuilder builder)
        {
            builder.Entity<CartonType>().ToTable("CARTON_TYPES");
            builder.Entity<CartonType>().HasKey(t => t.Name);
            builder.Entity<CartonType>().Property(t => t.Name).HasColumnName("CARTON_TYPE").HasMaxLength(10);
            builder.Entity<CartonType>().Property(t => t.Description).HasColumnName("DESCRIPTION").HasMaxLength(50);
            builder.Entity<CartonType>().Property(t => t.Height).HasColumnName("HEIGHT");
            builder.Entity<CartonType>().Property(t => t.Width).HasColumnName("WIDTH");
            builder.Entity<CartonType>().Property(t => t.Depth).HasColumnName("DEPTH");
            builder.Entity<CartonType>().Property(t => t.NumberOfSmallLabels).HasColumnName("NUM_SMALL_LABELS");
            builder.Entity<CartonType>().Property(t => t.NumberOfLargeLabels).HasColumnName("NUM_LARGE_LABELS");
        }

        private void BuildTypesOfSale(ModelBuilder builder)
        {
            builder.Entity<TypeOfSale>().ToTable("TYPES_OF_SALE");
            builder.Entity<TypeOfSale>().HasKey(t => t.Name);
            builder.Entity<TypeOfSale>().Property(t => t.Name).HasColumnName("TYPE_OF_SALE");
            builder.Entity<TypeOfSale>().Property(t => t.Description).HasColumnName("DESCRIPTION").HasMaxLength(50);
            builder.Entity<TypeOfSale>().Property(t => t.Nominal).HasColumnName("NOMINAL").HasMaxLength(10);
            builder.Entity<TypeOfSale>().Property(t => t.Department).HasColumnName("DEPARTMENT").HasMaxLength(10);
            builder.Entity<TypeOfSale>().Property(t => t.RealSale).HasColumnName("REAL_SALE").HasMaxLength(1);
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
            builder.Entity<SalesArticle>().Property(t => t.ArticleNumber).HasColumnName("ARTICLE_NUMBER")
                .HasMaxLength(14);
            builder.Entity<SalesArticle>().Property(t => t.InvoiceDescription).HasColumnName("INVOICE_DESCRIPTION")
                .HasMaxLength(100);
            builder.Entity<SalesArticle>().Property(t => t.CartonType).HasColumnName("CARTON_TYPE").HasMaxLength(10);
            builder.Entity<SalesArticle>().Property(t => t.EanCode).HasColumnName("EAN_CODE").HasMaxLength(13);
            builder.Entity<SalesArticle>().Property(t => t.PackingDescription).HasColumnName("PACKING_DESCRIPTION")
                .HasMaxLength(50);
            builder.Entity<SalesArticle>().Property(t => t.SaDiscountFamily).HasColumnName("SA_DISCOUNT_FAMILY")
                .HasMaxLength(10);
            builder.Entity<SalesArticle>().Property(t => t.TypeOfSale).HasColumnName("TYPE_OF_SALE").HasMaxLength(10);
            builder.Entity<SalesArticle>().Property(t => t.ForecastType).HasColumnName("FORECAST_TYPE").HasMaxLength(4);
            builder.Entity<SalesArticle>().Property(t => t.ForecastFromDate).HasColumnName("FORECAST_FROM_DATE");
            builder.Entity<SalesArticle>().Property(t => t.ForecastToDate).HasColumnName("FORECAST_TO_DATE");
            builder.Entity<SalesArticle>().Property(t => t.PhaseInDate).HasColumnName("PHASE_IN_DATE");
            builder.Entity<SalesArticle>().Property(t => t.PhaseOutDate).HasColumnName("PHASE_OUT_DATE");
            builder.Entity<SalesArticle>().Property(t => t.PercentageOfRootProductSales)
                .HasColumnName("PERCENTAGE_SALES");
            builder.Entity<SalesArticle>().Property(t => t.ArticleType).HasColumnName("ARTICLE_TYPE").HasMaxLength(1);
            builder.Entity<SalesArticle>().HasOne(t => t.SaCoreType);
            builder.Entity<SalesArticle>().HasMany(t => t.HoldStories).WithOne(e => e.SalesArticle);
        }

        private void BuildVatCode(ModelBuilder builder)
        {
            builder.Entity<VatCode>().ToTable("VATCODES");
            builder.Entity<VatCode>().HasKey(t => t.Code);
            builder.Entity<VatCode>().Property(t => t.Code).HasColumnName("VAT_CODE").HasMaxLength(1);
            builder.Entity<VatCode>().Property(t => t.Description).HasColumnName("DESCRIPTION").HasMaxLength(50);
            builder.Entity<VatCode>().Property(t => t.Rate).HasColumnName("RATE");
            builder.Entity<VatCode>().Property(t => t.Reason).HasColumnName("REASON");
            builder.Entity<VatCode>().Property(t => t.VatOnly).HasColumnName("VAT_ONLY").HasMaxLength(1);
            builder.Entity<VatCode>().Property(t => t.VatReturnId).HasColumnName("VAT_RETURN_ID");
        }

        private void BuildSaHoldStories(ModelBuilder builder)
        {
            EntityTypeBuilder<SaHoldStory> e = builder.Entity<SaHoldStory>();
            e.ToTable("SA_HOLD_STORIES");
            e.HasKey(t => t.HoldStoryId);
            e.Property(t => t.HoldStoryId).HasColumnName("HOLD_STORY_ID");
            e.Property(t => t.DateStarted).HasColumnName("DATE_STARTED");
            e.Property(t => t.DateFinished).HasColumnName("DATE_FINISHED");
            e.Property(t => t.ReasonStarted).HasColumnName("REASON_STARTED");
            e.Property(t => t.ReasonFinished).HasColumnName("REASON_FINISHED");
            e.Property(t => t.RootProduct).HasColumnName("ROOT_PRODUCT");
            e.Property(t => t.AnticipatedEndDate).HasColumnName("ANTICIPATED_END_DATE");
            e.Property(t => t.ArticleNumber).HasColumnName("ARTICLE_NUMBER");
            e.HasOne(t => t.PutOnHoldByEmployee);
            e.HasOne(t => t.TakenOffHoldByEmployee);
            e.HasOne<SalesArticle>(s => s.SalesArticle).WithMany(g => g.HoldStories)
                .HasForeignKey(s => s.ArticleNumber);
        }

        private void BuildEmployees(ModelBuilder builder)
        {
            EntityTypeBuilder<Employee> e = builder.Entity<Employee>();
            e.ToTable("AUTH_USER_NAME_VIEW");
            e.HasKey(t => t.Id);
            e.Property(t => t.Id).HasColumnName("USER_NUMBER");
            e.Property(t => t.FullName).HasColumnName("USER_NAME");
        }
    }
}
