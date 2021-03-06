﻿namespace Linn.Products.Messaging.Host
{
    using Autofac;
    using Linn.Products.IoC;

    public static class Configuration
    {
        public static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<AmazonCredentialsModule>();
            builder.RegisterModule<AmazonSqsModule>();
            builder.RegisterModule<LoggingModule>();
            //builder.RegisterModule<MessagingModule>();
            //builder.RegisterModule<PersistenceModule>();
            //builder.RegisterModule<ServiceModule>();
            // builder.RegisterReceiver("products.q", "products.dlx");

            builder.RegisterType<Listener>().AsSelf();

            return builder.Build();
        }
    }
}
