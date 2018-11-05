namespace Linn.Products.IoC
{
    using Autofac;
    using Domain.Linnapps;
    using Persistence.Linnapps;
    using Persistence.Linnapps.Repositories;
    using Linn.Products.Domain.Linnapps.Repositories;

    public class PersistenceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // persistence linnapps
            builder.RegisterType<TariffRepository>().As<ITariffRepository>();
            builder.RegisterType<ServiceDbContext>().InstancePerRequest();

            // linnapps repositories
            builder.RegisterType<CartonTypeRepository>().As<ICartonTypeRepository>();
            builder.RegisterType<SernosConfigRepository>().As<IRepository<SernosConfig, string>>();
        }
    }
}