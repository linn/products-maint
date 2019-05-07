namespace Linn.Products.IoC
{
    using Autofac;

    using Linn.Common.Persistence;
    using Linn.Common.Persistence.EntityFramework;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Domain.Linnapps.Repositories;
    using Linn.Products.Domain.Linnapps.SalesPackages;
    using Linn.Products.Domain.Linnapps.SernosTransactions;
    using Linn.Products.Persistence.Linnapps;
    using Linn.Products.Persistence.Linnapps.Repositories;

    using Microsoft.EntityFrameworkCore;

    public class PersistenceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ServiceDbContext>().AsSelf().As<DbContext>().InstancePerRequest();
            builder.RegisterType<TransactionManager>().As<ITransactionManager>();

            // linnapps repositories
            builder.RegisterType<CartonTypeRepository>().As<IRepository<CartonType, string>>();
            builder.RegisterType<SaCoreTypeRepository>().As<IRepository<SaCoreType, int>>();
            builder.RegisterType<SernosConfigRepository>().As<IRepository<SernosConfig, string>>();
            builder.RegisterType<SernosTransRepository>().As<IRepository<SernosTrans, string>>();
            builder.RegisterType<SernosCountRepository>().As<IRepository<SernosCount, string>>();
            builder.RegisterType<TypeOfSaleRepository>().As<IRepository<TypeOfSale, string>>();
            builder.RegisterType<SalesArticleRepository>().As<IRepository<SalesArticle, string>>();
            builder.RegisterType<SernosSequenceRepository>().As<IRepository<SernosSequence, string>>();
            builder.RegisterType<VatCodeRepository>().As<IRepository<VatCode, string>>();
            builder.RegisterType<TariffRepository>().As<IRepository<Tariff, int>>();
            builder.RegisterType<SaHoldStoryRepository>().As<IRepository<SaHoldStory, int>>();
            builder.RegisterType<ProductRangeRepository>().As<IRepository<ProductRange, int>>();
            builder.RegisterType<SalesPackageRepository>().As<IRepository<SalesPackage, int>>();
            builder.RegisterType<SerialNumberRepository>().As<IRepository<SerialNumber, int>>();
            builder.RegisterType<SernosNoteRepository>().As<IRepository<SernosNote, int>>();
            builder.RegisterType<EmployeeRepository>().As<IRepository<Employee, int>>();
            builder.RegisterType<RootProductRepository>().As<IRepository<RootProduct, string>>();
        }
    }
}