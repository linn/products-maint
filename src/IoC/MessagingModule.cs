namespace Linn.Production.IoC
{
    using Autofac;
    using Linn.Common.Messaging.RabbitMQ;
    using Linn.Common.Messaging.RabbitMQ.Autofac;
    using Linn.Common.Messaging.RabbitMQ.Configuration;
    using Linn.Products.Domain.Dispatchers;
    using Linn.Products.Messaging.Dispatchers;

    public class MessagingModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterConnectionBuilder();
            builder.RegisterInfiniteRetryStrategy();
            builder.RegisterConnector();
            builder.RegisterMessageDispatcher();
            builder.RegisterReceiver("products-maint.q", "products-maint.dlx");
            builder.RegisterSender("products-maint.x", "Products-Maint Message Queuer");

            builder.RegisterType<SalesPartUpdatedDispatcher>().As<ISalesPartUpdatedDispatcher>();

            builder.RegisterType<RabbitConfiguration>().As<IRabbitConfiguration>();
            builder.RegisterType<RabbitTerminator>().As<IRabbitTerminator>();
        }
    }
}