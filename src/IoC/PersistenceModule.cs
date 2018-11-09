namespace Linn.Products.IoC
{
    using Autofac;

    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Domain.Linnapps.Repositories;
    using Linn.Products.Persistence.Linnapps;
    using Linn.Products.Persistence.Linnapps.Repositories;

    public class PersistenceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ServiceDbContext>().InstancePerRequest();

            // linnapps repositories
            builder.RegisterType<CartonTypeRepository>().As<ICartonTypeRepository>();
            builder.RegisterType<SACoreTypeRepository>().As<IRepository<SaCoreType, int>>();
            builder.RegisterType<SernosConfigRepository>().As<IRepository<SernosConfig, string>>();
            builder.RegisterType<TariffRepository>().As<ITariffRepository>();
        }
    }
}