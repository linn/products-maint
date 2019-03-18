namespace Linn.Products.Persistence.Linnapps
{
    using Linn.Common.Configuration;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Domain.Linnapps.SalesPackages;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.Extensions.Logging;

    public class ServiceDbContext : DbContext
    {
        public static readonly Microsoft.Extensions.Logging.LoggerFactory _myLoggerFactory =
            new LoggerFactory(new[] {
                                        new Microsoft.Extensions.Logging.Debug.DebugLoggerProvider()
                                    });

        public DbSet<SaCoreType> SaCoreTypes { get; set; }

        public DbSet<SernosConfig> SernosConfigs { get; set; }

        public DbSet<SernosSequence> SernosSequences { get; set; }

        public DbSet<Tariff> Tariffs { get; set; }

        public DbSet<SalesArticle> SalesArticles { get; set; }

        public DbSet<TypeOfSale> TypesOfSale { get; set; }

        public DbSet<CartonType> CartonTypes { get; set; }

        public DbSet<SaHoldStory> SaHoldStories { get; set; }

        public DbSet<VatCode> VatCodes { get; set; }

        public DbSet<ProductRange> ProductRanges { get; set; }

        public DbSet<Employee> Employees { get; set; }
        
        public DbSet<SalesPackage> SalesPackages { get; set; }

        public DbSet<SernosNote> SernosNotes { get; set; }

        public DbSet<SerialNumber> SerialNumbers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            this.BuildSaCoreType(builder);
            this.BuildSernosConfig(builder);
            this.BuildSernosSequence(builder);
            this.BuildTariffs(builder);
            this.BuildSalesArticles(builder);
            this.BuildTypesOfSale(builder);
            this.BuildCartonTypes(builder);
            this.BuildSaHoldStories(builder);
            this.BuildVatCode(builder);
            this.BuildProductRanges(builder);
            this.BuildEmployees(builder);
            this.BuildSalesPackages(builder);
            this.BuildSernosNotes(builder);
            this.BuildSerialNumbers(builder);
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
            optionsBuilder.EnableSensitiveDataLogging(true);

            base.OnConfiguring(optionsBuilder);
        }

        // TODO come back to this and sernos...
        private void BuildSernosNotes(ModelBuilder builder)
        {
            builder.Entity<SernosNote>().ToTable("SERNOS_NOTES");
            builder.Entity<SernosNote>().HasKey(r => r.SernosNoteId);
            builder.Entity<SernosNote>().Property(r => r.SernosNoteId).HasColumnName("SERNOS_NOTE_ID");
            builder.Entity<SernosNote>().Property(r => r.SernosNotes).HasColumnName("SERNOS_NOTES").HasMaxLength(2000);
            builder.Entity<SernosNote>().Property(r => r.SernosGroup).HasColumnName("SERNOS_GROUP").HasMaxLength(10);
            builder.Entity<SernosNote>().Property(r => r.SernosNumber).HasColumnName("SERNOS_NUMBER");
//            builder.Entity<SernosNote>().Property(r => r.SernosTref).HasColumnName("SERNOS_TREF");
            builder.Entity<SernosNote>().Property(r => r.TransCode).HasColumnName("TRANS_CODE");
            builder.Entity<SernosNote>().HasOne(t => t.SerialNumber);
        }

        private void BuildSerialNumbers(ModelBuilder builder)
        {
            builder.Entity<SerialNumber>().ToTable("SERNOS");
            builder.Entity<SerialNumber>().HasKey(s => s.SernosTref);
            builder.Entity<SerialNumber>().Property(s => s.SernosTref).HasColumnName("SERNOS_TREF");
            builder.Entity<SerialNumber>().Property(s => s.SernosGroup).HasColumnName("SERNOS_GROUP").HasMaxLength(10);
            builder.Entity<SerialNumber>().Property(s => s.SernosNumber).HasColumnName("SERNOS_NUMBER");
            builder.Entity<SerialNumber>().Property(s => s.SernosDate).HasColumnName("SERNOS_DATE");
            builder.Entity<SerialNumber>().Property(s => s.DocumentType).HasColumnName("DOCUMENT_TYPE").HasMaxLength(2);
            builder.Entity<SerialNumber>().Property(s => s.DocumentNumber).HasColumnName("DOCUMENT_NUMBER");
            builder.Entity<SerialNumber>().Property(s => s.DocumentLine).HasColumnName("DOCUMENT_LINE");
            builder.Entity<SerialNumber>().Property(s => s.DatePostedToVax).HasColumnName("DATE_POSTED_TO_VAX");
            builder.Entity<SerialNumber>().Property(s => s.OutletNumber).HasColumnName("OUTLET_NUMBER");
            builder.Entity<SerialNumber>().Property(s => s.PrevSernosNumber).HasColumnName("PREV_SERNOS_NUMBER");
            builder.Entity<SerialNumber>().Property(s => s.OutletNumber).HasColumnName("OUTLET_NUMBER");
            
            builder.Entity<SerialNumber>().Property(s => s.AccountId).HasColumnName("ACCOUNT_ID");
            builder.Entity<SerialNumber>().Property(s => s.CreatedBy).HasColumnName("CREATED_BY");
            builder.Entity<SerialNumber>().Property(s => s.TransCode).HasColumnName("TRANS_CODE");

            // builder.Entity<SerialNumber>().HasOne(s => s.SalesArticle);
            // builder.Entity<SerialNumber>().HasOne(s => s.SalesArticle).WithMany(g => g.SerialNumbers);

            builder.Entity<SerialNumber>().Property(s => s.ArticleNumber).HasColumnName("ARTICLE_NUMBER");
            builder.Entity<SerialNumber>().HasOne(s => s.SalesArticle).WithMany(g => g.SerialNumbers)
                .HasForeignKey(s => s.ArticleNumber);
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

        private void BuildSalesPackages(ModelBuilder builder)
        {
            builder.Entity<SalesPackage>().ToTable("SALES_PACKAGES");
            builder.Entity<SalesPackage>().HasKey(s => s.Id);
            builder.Entity<SalesPackage>().Property(s => s.Id).HasColumnName("BRIDGE_ID");
            builder.Entity<SalesPackage>().Property(s => s.SalesPackageId).HasColumnName("SALES_PACKAGE_ID").HasMaxLength(10);
            builder.Entity<SalesPackage>().Property(s => s.Description).HasColumnName("DESCRIPTION").HasMaxLength(50);
            builder.Entity<SalesPackage>().HasMany(s => s.Elements);


            builder.Entity<SalesPackageElement>().ToTable("SALES_PACKAGE_ELEMENTS");
            builder.Entity<SalesPackageElement>().HasKey(s => new { s.SalesPackageId, s.ElementType });
            builder.Entity<SalesPackageElement>().Property(s => s.SalesPackageId).HasColumnName("SALES_PACKAGE_ID").HasMaxLength(10);
            builder.Entity<SalesPackageElement>().Property(s => s.ElementType).HasColumnName("PACKAGE_ELEMENT_TYPE").HasMaxLength(10);
            builder.Entity<SalesPackageElement>().Property(s => s.Sequence).HasColumnName("SPE_SEQUENCE");
            builder.Entity<SalesPackageElement>().Property(s => s.Quantity).HasColumnName("QUANTITY");
            builder.Entity<SalesPackageElement>().HasMany(s => s.Packages);

            builder.Entity<SalesPackageElementType>().ToTable("SALES_PACKAGE_EL_TYPES");
            builder.Entity<SalesPackageElementType>().HasKey(s => s.ElementType);
            builder.Entity<SalesPackageElementType>().Property(s => s.ElementType).HasColumnName("PACKAGE_ELEMENT_TYPE").HasMaxLength(10);
            builder.Entity<SalesPackageElementType>().Property(s => s.Description).HasColumnName("PACKAGE_ELEMENT_TYPE_DESCRIPTI").HasMaxLength(50);

            builder.Entity<SalesPackageElementJoin>().ToTable("SALES_PACKAGE_ELEMENT_JOINS");
            builder.Entity<SalesPackageElementJoin>().HasKey(s => s.Id);
            builder.Entity<SalesPackageElementJoin>().Property(s => s.Id).HasColumnName("ID");
            builder.Entity<SalesPackageElementJoin>().Property(s => s.BridgeId).HasColumnName("BRIDGE_ID");
            builder.Entity<SalesPackageElementJoin>().Property(s => s.SalesPackageId).HasColumnName("SALES_PACKAGE_ID").HasMaxLength(10);
            builder.Entity<SalesPackageElementJoin>().Property(s => s.ElementType).HasColumnName("PACKAGE_ELEMENT_TYPE").HasMaxLength(10);
            builder.Entity<SalesPackageElementJoin>().HasOne(j => j.SalesPackage)
                .WithMany(r => r.Elements)
                .HasForeignKey(j => j.BridgeId);

            builder.Entity<SalesPackageElementJoin>().HasOne(j => j.SalesPackageElement)
                .WithMany(d => d.Packages)
                .HasForeignKey(j => new { j.SalesPackageId, j.ElementType });
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

        private void BuildSernosSequence(ModelBuilder builder)
        {
            builder.Entity<SernosSequence>().ToTable("SERNOS_SEQUENCES");
            builder.Entity<SernosSequence>().HasKey(t => t.SequenceName);
            builder.Entity<SernosSequence>().Property(t => t.SequenceName).HasColumnName("SEQUENCE_NAME").HasMaxLength(10);
            builder.Entity<SernosSequence>().Property(t => t.Description).HasColumnName("DESCRIPTION").HasMaxLength(50);
            builder.Entity<SernosSequence>().Property(t => t.NextSerialNumber).HasColumnName("NEXT_SERIAL_NUMBER");
            builder.Entity<SernosSequence>().Property(t => t.DateClosed).HasColumnName("DATE_CLOSED");
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
            builder.Entity<SalesArticle>().HasMany(t => t.SerialNumbers).WithOne(e => e.SalesArticle);
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
