
namespace Linn.Products.IoC
{
    using System.Transactions;

    using Autofac;

    using Linn.Common.Persistence;
    using Linn.Products.Persistence;
    using Linn.Products.Persistence.Linnapps;

    using Microsoft.EntityFrameworkCore;

    class DatabaseModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ServiceDbContext>().AsSelf().As<DbContext>().InstancePerRequest();
        }
    }
}
