namespace Linn.Products.IoC
{
    using Autofac;
    using Common.Persistence;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Domain.Linnapps.Repositories;
    using Linn.Products.Persistence.Linnapps;
    using Linn.Products.Persistence.Linnapps.Repositories;

    public class PersistenceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ServiceDbContext>().InstancePerRequest();
            builder.RegisterType<TransactionManager>().As<ITransactionManager>();

            // linnapps repositories
            builder.RegisterType<CartonTypeRepository>().As<ICartonTypeRepository>();
            builder.RegisterType<SaCoreTypeRepository>().As<Persistence.Linnapps.IRepository<SaCoreType, int>>();
            builder.RegisterType<SernosConfigRepository>().As<Persistence.Linnapps.IRepository<SernosConfig, string>>();
            builder.RegisterType<TypeOfSaleRepository>().As<Persistence.Linnapps.IRepository<TypeOfSale, string>>();
            builder.RegisterType<TariffRepository>().As<ITariffRepository>();
        }
    }
}