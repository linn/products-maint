namespace Linn.Products.IoC
{
    using Autofac;

    using Linn.Common.Configuration;
    using Linn.Common.Proxy;
    using Linn.Products.Domain.Linnapps.RemoteServices;
    using Linn.Products.Domain.Linnapps.Reports;
    using Linn.Products.Facade.Services;
    using Linn.Products.Proxy;

    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // domain services
            builder.RegisterType<EanCodeReportService>().As<IEanCodeReportService>();

            // facade services
            builder.RegisterType<SalesArticleReportService>().As<ISalesArticleReportService>();
            builder.RegisterType<TariffService>().As<ITariffService>();

            // rest client proxies
            builder.RegisterType<RestClient>().As<IRestClient>();
            builder.RegisterType<SalesArticleProxy>().As<ISalesArticleService>().WithParameter("rootUri", ConfigurationManager.Configuration["PROXY_ROOT"]);
        }
    }
}