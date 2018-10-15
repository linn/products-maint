namespace Linn.Products.IoC
{
    using Autofac;

    using Linn.Products.Domain.Linnapps.Repositories;
    using Linn.Products.Persistence.Linnapps.Repositories;

    public class PersistenceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // linnapps repositories
            builder.RegisterType<CartonTypeRepository>().As<ICartonTypeRepository>();
        }
    }
}