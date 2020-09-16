namespace Linn.Products.Persistence
{
    using Linn.Common.Configuration;
    using Linn.Products.Domain.Products;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;

    public class ProductsServiceDbContext : DbContext
    {
        public static readonly LoggerFactory MyLoggerFactory =
            new LoggerFactory(new[] { new Microsoft.Extensions.Logging.Debug.DebugLoggerProvider() });

        public DbSet<ProductSalesPart> SalesParts { get; set; }


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
            builder.Entity<ProductSalesPart>().ToTable("SALES_PARTS");
            builder.Entity<ProductSalesPart>().HasKey(t => t.Id);
            builder.Entity<ProductSalesPart>().Property(t => t.Id).HasColumnName("ID")
                .HasMaxLength(10);
            builder.Entity<ProductSalesPart>().HasOne<Tariff>(f => f.Tariff);
            builder.Entity<ProductSalesPart>().Property(t => t.Description).HasColumnName("DESCRIPTION").HasMaxLength(100);
            builder.Entity<ProductSalesPart>().Property(t => t.BarcodePrefix).HasColumnName("BARCODEPREFIX").HasMaxLength(255);
            builder.Entity<ProductSalesPart>().Property(t => t.BarcodePrefix).HasColumnName("BARCODEPREFIX").HasMaxLength(255);
            builder.Entity<ProductSalesPart>().Property(t => t.Name).HasColumnName("NAME").HasMaxLength(14);
            builder.Entity<ProductSalesPart>().Property(t => t.CountryOfOrigin).HasColumnName("COUNTRYOFORIGIN");
            builder.Entity<ProductSalesPart>().Property(t => t.Ean).HasColumnName("EAN");
            builder.Entity<ProductSalesPart>().Property(t => t.MinimumOrderQuantity).HasColumnName("MINIMUMORDERQUANTITY");
            builder.Entity<ProductSalesPart>().Property(t => t.MaximumOrderQuantity).HasColumnName("MAXIMUMORDERQUANTITY");
            builder.Entity<ProductSalesPart>().Property(t => t.OrderMultiple).HasColumnName("ORDERMULTIPLE");
            builder.Entity<ProductSalesPart>().Property(t => t.PhasedInOn).HasColumnName("PHASEDINON");
            builder.Entity<ProductSalesPart>().Property(t => t.PhasedOutOn).HasColumnName("PHASEDOUTON");
            builder.Entity<ProductSalesPart>().Property(t => t.PhasedOutBy).HasColumnName("PHASEDOUTBY");
            builder.Entity<ProductSalesPart>().Property(t => t.ShortDescription).HasColumnName("SHORTDESCRIPTION").HasMaxLength(100);
            builder.Entity<ProductSalesPart>().Property(t => t.VatCode).HasColumnName("VATCODE_ID");
            builder.Entity<ProductSalesPart>().HasOne<ProductSalesPart>(f => f.ReplacedByPart);
            builder.Entity<ProductSalesPart>().HasOne<RootProduct>(f => f.RootProduct);
            builder.Entity<ProductSalesPart>().HasOne<Carton>(f => f.Carton);
            builder.Entity<ProductSalesPart>().Property(t => t.CreatedBy).HasColumnName("CREATEDBY");
            builder.Entity<ProductSalesPart>().Property(t => t.CreatedOn).HasColumnName("CREATEDON");
            builder.Entity<ProductSalesPart>().Property(t => t.WeightInKg).HasColumnName("WEIGHTINKG");
            builder.Entity<ProductSalesPart>().Property(t => t.UnitedStatesTariffCode).HasColumnName("USTARIFFCODE");
            builder.Entity<ProductSalesPart>().HasOne<Domain.Products.TypeOfSale>(f => f.TypeOfSale);
            builder.Entity<ProductSalesPart>().Property(t => t.ExDem).HasColumnName("EXDEM");
            builder.Entity<ProductSalesPart>().HasOne<Cit>(f => f.Cit);
            builder.Entity<ProductSalesPart>().HasOne<SerialNumberSource>(f => f.SerialNumberSource);
            builder.Entity<ProductSalesPart>().HasOne<TypeOfSerialNumber>(f => f.TypeOfSerialNumber);
            builder.Entity<ProductSalesPart>().HasOne<OrderType>(f => f.OrderType);


            //need mapping for labels 
            //this.HasMany(s => s.Labels).Access.CamelCaseField().Cascade.All().AsMap(s => s.Type).KeyColumn("salespart_id");


            //fix the below for sales part attributes
            //builder.Entity<ProductSalesPart>().HasMany<AttributeValue>(f => f.Attributes).WithOne(x=>x.).HasForeignKey();
            //this.HasManyToMany(s => s.Attributes).Cascade.All().Table("SALES_PART_ATTRIBUTES");


            builder.Entity<ProductSalesPart>().Property(t => t.Notes).HasColumnName("NOTES").HasMaxLength(2000);
            builder.Entity<ProductSalesPart>().Property(t => t.OrderInformation).HasColumnName("ORDERINFORMATION").HasMaxLength(2000);

            builder.Entity<ProductSalesPart>().Property(t => t.AccountingCompany).HasColumnName("ACCOUNTINGCOMPANY_ID");
            builder.Entity<ProductSalesPart>().Property(t => t.ExtraBuildWeeks).HasColumnName("EXTRABUILDWEEKS");


            builder.Entity<ProductSalesPart>().Property(t => t.WeeeProduct).HasColumnName("WEEE_PRODUCT");
            builder.Entity<ProductSalesPart>().Property(t => t.NettWeight).HasColumnName("NETT_WEIGHT");

            builder.Entity<ProductSalesPart>().Property(t => t.DimensionOver50Cm).HasColumnName("DIMENSION_OVER_50_CM");
            builder.Entity<ProductSalesPart>().Property(t => t.WeeeCategory).HasColumnName("WEEE_CATEGORY");


            builder.Entity<ProductSalesPart>().Property(t => t.MainsCablesPerProduct).HasColumnName("MAINS_CABLES_PER_PRODUCT");
            builder.Entity<ProductSalesPart>().Property(t => t.PackagingNettWeight).HasColumnName("PACKAGING_NETT_WEIGHT");
            builder.Entity<ProductSalesPart>().Property(t => t.PackagingFoamNettWeight).HasColumnName("PACKAGING_FOAM_NETT_WEIGHT");


        }
    }
}