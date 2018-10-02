namespace Linn.Products.IoC
{
    using Autofac;
    using Domain.Repositories;
    using Facade.Services;
    using Persistence.Linnapps;
    using Persistence.Linnapps.Repositories;

    public class PersistenceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // persistance linnapps
            builder.RegisterType<TariffRepository>().As<ITariffRepository>();
            builder.RegisterType<ServiceDbContext>().InstancePerRequest();
        }
    }
}