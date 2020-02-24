namespace Linn.Products.Persistence.Linnapps
{
    using Linn.Common.Configuration;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Domain.Linnapps.SalesPackages;
    using Linn.Products.Domain.Linnapps.SernosTransactions;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.Extensions.Logging;

    public class ServiceDbContext : DbContext
    {
        public static readonly LoggerFactory MyLoggerFactory =
            new LoggerFactory(new[] { new Microsoft.Extensions.Logging.Debug.DebugLoggerProvider() });

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

        public DbSet<RootProduct> RootProducts { get; set; }

        public DbSet<SernosNote> SernosNotes { get; set; }

        public DbSet<SerialNumber> SerialNumbers { get; set; }

        public DbSet<SernosTrans> SerialNumberTransactionTypes { get; set; }

        public DbSet<SernosCount> SerialNumberTransactionCountTypes { get; set; }

        public DbSet<ArchiveSerialNumber> ArchiveSerialNumbers { get; set; }

        public DbQuery<SalesAnalysis> SalesAnalyses { get; set; }

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
            this.BuildRootProducts(builder);
            this.BuildSernosNotes(builder);
            this.BuildSerialNumbers(builder);
            this.BuildSerialNumberTransactions(builder);
            this.BuildArchiveSerialNumbers(builder);
            this.QuerySalesAnalyses(builder);
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
            optionsBuilder.UseLoggerFactory(MyLoggerFactory);
            optionsBuilder.EnableSensitiveDataLogging(true);
            base.OnConfiguring(optionsBuilder);
        }

        private void BuildSerialNumberTransactions(ModelBuilder builder)
        {
            builder.Entity<SernosTrans>().ToTable("SERNOS_TRANS");
            builder.Entity<SernosTrans>().HasKey(r => r.TransCode);
            builder.Entity<SernosTrans>().Property(r => r.TransCode).HasColumnName("TRANS_CODE").HasMaxLength(10);
            builder.Entity<SernosTrans>().Property(r => r.TransDescription).HasColumnName("TRANS_DESCRIPTION").HasMaxLength(50);
            builder.Entity<SernosTrans>().Property(r => r.Comments).HasColumnName("COMMENTS").HasMaxLength(2000);
            builder.Entity<SernosTrans>().Property(r => r.ManualPost).HasColumnName("MANUAL_POST").HasMaxLength(1);
            builder.Entity<SernosTrans>().Property(r => r.UpdateLastTransaction).HasColumnName("UPDATE_LAST_TRANSACTION").HasMaxLength(1);
            builder.Entity<SernosTrans>().Property(r => r.UpdateBuiltBy).HasColumnName("UPDATE_BUILT_BY").HasMaxLength(1);
            builder.Entity<SernosTrans>().Property(r => r.UpdateLastAccount).HasColumnName("UPDATE_LAST_ACCOUNT").HasMaxLength(1);
            builder.Entity<SernosTrans>().HasMany(t => t.SernosTransCounts).WithOne(e => e.SernosTrans);

            builder.Entity<SernosTransCount>().ToTable("SERNOS_TRANS_COUNTS");
            builder.Entity<SernosTransCount>().HasKey(s => new { s.TransCode, s.SernosCount });
            builder.Entity<SernosTransCount>().Property(r => r.TransCode).HasColumnName("TRANS_CODE").HasMaxLength(10);
            builder.Entity<SernosTransCount>().Property(r => r.SernosCount).HasColumnName("SERNOS_COUNT").HasMaxLength(10);
            builder.Entity<SernosTransCount>().Property(r => r.CheckError).HasColumnName("CHECK_ERROR").HasMaxLength(1);
            builder.Entity<SernosTransCount>().Property(r => r.CheckErrorMess).HasColumnName("CHECK_ERROR_MESS").HasMaxLength(128);
            builder.Entity<SernosTransCount>().Property(r => r.CorrectValue).HasColumnName("CORRECT_VALUE").HasMaxLength(10);
            builder.Entity<SernosTransCount>().Property(r => r.CountIncrement).HasColumnName("COUNT_INCREMENT").HasMaxLength(10);
            builder.Entity<SernosTransCount>().HasOne<SernosTrans>(s => s.SernosTrans).WithMany(g => g.SernosTransCounts)
                .HasForeignKey(s => s.TransCode);

            builder.Entity<SernosCount>().ToTable("SERNOS_COUNTS");
            builder.Entity<SernosCount>().HasKey(r => r.Name);
            builder.Entity<SernosCount>().Property(r => r.Name).HasColumnName("NAME").HasMaxLength(10);
            builder.Entity<SernosCount>().Property(r => r.Description).HasColumnName("DESCRIPTION").HasMaxLength(50);
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
            builder.Entity<SalesPackage>().Property(s => s.SalesPackageId).HasColumnName("SALES_PACKAGE_ID")
                .HasMaxLength(10);
            builder.Entity<SalesPackage>().Property(s => s.Description).HasColumnName("DESCRIPTION").HasMaxLength(50);
            builder.Entity<SalesPackage>().HasMany(s => s.Elements);

            builder.Entity<SalesPackageElement>().ToTable("SALES_PACKAGE_ELEMENTS");
            builder.Entity<SalesPackageElement>().HasKey(s => new { s.SalesPackageId, s.ElementType });
            builder.Entity<SalesPackageElement>().Property(s => s.SalesPackageId).HasColumnName("SALES_PACKAGE_ID")
                .HasMaxLength(10);
            builder.Entity<SalesPackageElement>().Property(s => s.ElementType).HasColumnName("PACKAGE_ELEMENT_TYPE")
                .HasMaxLength(10);
            builder.Entity<SalesPackageElement>().Property(s => s.Sequence).HasColumnName("SPE_SEQUENCE");
            builder.Entity<SalesPackageElement>().Property(s => s.Quantity).HasColumnName("QUANTITY");
            builder.Entity<SalesPackageElement>().HasMany(s => s.Packages);

            builder.Entity<SalesPackageElementType>().ToTable("SALES_PACKAGE_EL_TYPES");
            builder.Entity<SalesPackageElementType>().HasKey(s => s.ElementType);
            builder.Entity<SalesPackageElementType>().Property(s => s.ElementType).HasColumnName("PACKAGE_ELEMENT_TYPE")
                .HasMaxLength(10);
            builder.Entity<SalesPackageElementType>().Property(s => s.Description)
                .HasColumnName("PACKAGE_ELEMENT_TYPE_DESCRIPTI").HasMaxLength(50);

            builder.Entity<SalesPackageElementJoin>().ToTable("SALES_PACKAGE_ELEMENT_JOINS");
            builder.Entity<SalesPackageElementJoin>().HasKey(s => s.Id);
            builder.Entity<SalesPackageElementJoin>().Property(s => s.Id).HasColumnName("ID");
            builder.Entity<SalesPackageElementJoin>().Property(s => s.BridgeId).HasColumnName("BRIDGE_ID");
            builder.Entity<SalesPackageElementJoin>().Property(s => s.SalesPackageId).HasColumnName("SALES_PACKAGE_ID")
                .HasMaxLength(10);
            builder.Entity<SalesPackageElementJoin>().Property(s => s.ElementType).HasColumnName("PACKAGE_ELEMENT_TYPE")
                .HasMaxLength(10);
            builder.Entity<SalesPackageElementJoin>().HasOne(j => j.SalesPackage).WithMany(r => r.Elements)
                .HasForeignKey(j => j.BridgeId);

            builder.Entity<SalesPackageElementJoin>().HasOne(j => j.SalesPackageElement).WithMany(d => d.Packages)
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

        private void BuildArchiveSerialNumbers(ModelBuilder builder)
        {
            builder.Entity<ArchiveSerialNumber>().ToTable("SERNOS_ARCH_VIEW");
            builder.Entity<ArchiveSerialNumber>().HasKey(s => new { s.SernosGroup, s.TransCode, s.SernosDate });
            builder.Entity<ArchiveSerialNumber>().Property(s => s.SernosGroup).HasColumnName("SERNOS_GROUP")
                .HasMaxLength(10);
            builder.Entity<ArchiveSerialNumber>().Property(s => s.SernosNumber).HasColumnName("SERNOS_NUMBER");
            builder.Entity<ArchiveSerialNumber>().Property(s => s.TransCode).HasColumnName("TRANS_CODE")
                .HasMaxLength(10);
            builder.Entity<ArchiveSerialNumber>().Property(s => s.ArticleNumber).HasColumnName("ARTICLE_NUMBER")
                .HasMaxLength(10);
            builder.Entity<ArchiveSerialNumber>().Property(s => s.SernosDate).HasColumnName("SERNOS_DATE");
            builder.Entity<ArchiveSerialNumber>().Property(s => s.DocumentType).HasColumnName("DOCUMENT_TYPE")
                .HasMaxLength(2);
            builder.Entity<ArchiveSerialNumber>().Property(s => s.DocumentNumber).HasColumnName("DOCUMENT_NUMBER");
            builder.Entity<ArchiveSerialNumber>().Property(s => s.DocumentLine).HasColumnName("DOCUMENT_LINE");
            builder.Entity<ArchiveSerialNumber>().Property(s => s.AccountId).HasColumnName("ACCOUNT_ID");
            builder.Entity<ArchiveSerialNumber>().Property(s => s.OutletNumber).HasColumnName("OUTLET_NUMBER");
            builder.Entity<ArchiveSerialNumber>().Property(s => s.CreatedBy).HasColumnName("CREATED_BY");
        }

        private void BuildSerialNumbers(ModelBuilder builder)
        {
            builder.Entity<SerialNumber>().ToTable("SERNOS");
            builder.Entity<SerialNumber>().HasKey(s => s.SernosTRef);
            builder.Entity<SerialNumber>().HasAlternateKey(r => new { r.SernosGroup, r.SernosTRef, r.TransCode });
            builder.Entity<SerialNumber>().Property(s => s.SernosTRef).HasColumnName("SERNOS_TREF");
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
            builder.Entity<SerialNumber>().Property(s => s.ArticleNumber).HasColumnName("ARTICLE_NUMBER");
        }

        private void BuildSernosNotes(ModelBuilder builder)
        {
            builder.Entity<SernosNote>().ToTable("SERNOS_NOTES");
            builder.Entity<SernosNote>().HasKey(r => new { r.SernosNoteId });
            builder.Entity<SernosNote>().HasAlternateKey(r => new { r.SernosGroup, r.TransCode, r.SernosNumber });
            builder.Entity<SernosNote>().Property(r => r.SernosNoteId).HasColumnName("SERNOS_NOTE_ID");
            builder.Entity<SernosNote>().Property(r => r.SernosNotes).HasColumnName("SERNOS_NOTES").HasMaxLength(2000);
            builder.Entity<SernosNote>().Property(r => r.SernosGroup).HasColumnName("SERNOS_GROUP").HasMaxLength(10);
            builder.Entity<SernosNote>().Property(r => r.SernosNumber).HasColumnName("SERNOS_NUMBER");
            builder.Entity<SernosNote>().Property(r => r.SernosTRef).HasColumnName("SERNOS_TREF");
            builder.Entity<SernosNote>().Property(r => r.TransCode).HasColumnName("TRANS_CODE");
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
            builder.Entity<SernosSequence>().Property(t => t.SequenceName).HasColumnName("SEQUENCE_NAME")
                .HasMaxLength(10);
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
            builder.Entity<Tariff>().Property(t => t.EnteredBy).HasColumnName("ENTERED_BY");
            builder.Entity<Tariff>().Property(t => t.ChangedBy).HasColumnName("CHANGED_BY");
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
            builder.Entity<SalesArticle>().Property(t => t.LastHoldStoryId).HasColumnName("HOLD_STORY_ID");
            builder.Entity<SalesArticle>().Property(t => t.PercentageOfRootProductSales)
                .HasColumnName("PERCENTAGE_SALES");
            builder.Entity<SalesArticle>().Property(t => t.ArticleType).HasColumnName("ARTICLE_TYPE").HasMaxLength(1);
            builder.Entity<SalesArticle>().Property(t => t.RootProduct).HasColumnName("ROOT_PRODUCT");
            builder.Entity<SalesArticle>().Property(t => t.TariffId).HasColumnName("TARIFF_ID");
            builder.Entity<SalesArticle>().Property(t => t.TypeOfSerialNumber).HasColumnName("TYPE_OF_SERIAL_NUMBER").HasMaxLength(2);
            builder.Entity<SalesArticle>().Property(t => t.ProductIdOnChip).HasColumnName("PRODUCT_ID_ON_CHIP")
                .HasMaxLength(1);
            builder.Entity<SalesArticle>().HasOne(t => t.SaCoreType);
            builder.Entity<SalesArticle>().HasMany(t => t.HoldStories).WithOne(e => e.SalesArticle);
            builder.Entity<SalesArticle>().Property(t => t.Weight).HasColumnName("WEIGHT");
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
            e.Property(t => t.AnticipatedEndDate).HasColumnName("ANTICIPATED_END_DATE");
            e.Property(t => t.ArticleNumber).HasColumnName("ARTICLE_NUMBER");
            e.Property(t => t.RootProductName).HasColumnName("ROOT_PRODUCT");
            e.HasOne(t => t.PutOnHoldByEmployee);
            e.HasOne(t => t.TakenOffHoldByEmployee);
            e.HasOne<SalesArticle>(s => s.SalesArticle).WithMany(g => g.HoldStories)
                .HasForeignKey(s => s.ArticleNumber);
            e.HasOne<RootProduct>(s => s.RootProduct).WithMany(g => g.HoldStories)
                .HasForeignKey(s => s.RootProductName);
        }

        private void BuildEmployees(ModelBuilder builder)
        {
            EntityTypeBuilder<Employee> e = builder.Entity<Employee>();
            e.ToTable("AUTH_USER_NAME_VIEW");
            e.HasKey(t => t.Id);
            e.Property(t => t.Id).HasColumnName("USER_NUMBER");
            e.Property(t => t.FullName).HasColumnName("USER_NAME");
        }

        private void BuildRootProducts(ModelBuilder builder)
        {
            EntityTypeBuilder<RootProduct> e = builder.Entity<RootProduct>();
            e.ToTable("ROOT_PRODS");
            e.HasKey(t => t.Name);
            e.Property(t => t.Name).HasColumnName("ROOT_PRODUCT");
            e.Property(t => t.Description).HasColumnName("DESCRIPTION");
            e.HasMany(t => t.HoldStories).WithOne(f => f.RootProduct);
        }

        private void QuerySalesAnalyses(ModelBuilder builder)
        {
            var q = builder.Query<SalesAnalysis>();
            q.ToView("SALES_ANALYSIS");
            q.Property(e => e.SanlId).HasColumnName("SANL_ID");
            q.Property(e => e.ArticleNumber).HasColumnName("ARTICLE_NUMBER").HasMaxLength(14);
            q.Property(e => e.AccountingCompany).HasColumnName("ACCOUNTING_COMPANY").HasMaxLength(10);
            q.Property(e => e.CountryCode).HasColumnName("COUNTRY_CODE").HasMaxLength(2);
            q.Property(e => e.DocumentType).HasColumnName("DOCUMENT_TYPE").HasMaxLength(1);
            q.Property(e => e.SanlDate).HasColumnName("SANL_DATE");
            q.Property(e => e.Quantity).HasColumnName("QUANTITY");
        }
    }
}