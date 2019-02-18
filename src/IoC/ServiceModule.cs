namespace Linn.Products.IoC
{
    using Autofac;

    using Linn.Common.Configuration;
    using Linn.Common.Facade;
    using Linn.Common.Proxy;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Domain.Linnapps.RemoteServices;
    using Linn.Products.Domain.Linnapps.Reports;
    using Linn.Products.Domain.Reports;
    using Linn.Products.Domain.Repositories;
    using Linn.Products.Facade.Services;
    using Linn.Products.Proxy;
    using Linn.Products.Resources;

    using ISaHoldStoriesReportService = Linn.Products.Domain.Linnapps.Reports.ISaHoldStoriesReportService;
    using SaHoldStoriesReportService = Linn.Products.Facade.SaHoldStoriesReportService;

    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // domain services
            builder.RegisterType<EanCodeReportService>().As<IEanCodeReportService>();
            builder.RegisterType<CartonDetailsReportService>().As<ICartonDetailsReportService>();
            builder.RegisterType<ProductReports>().As<IProductReports>();
            builder.RegisterType<StockTriggerLevelReportService>().As<IStockTriggerLevelReportService>();
            builder.RegisterType<Domain.Linnapps.Reports.SaHoldStoriesReportService>()
                .As<ISaHoldStoriesReportService>();

            // facade services
            builder.RegisterType<SalesArticleReportService>().As<ISalesArticleReportService>();
            builder.RegisterType<TariffService>().As<ITariffService>();
            builder.RegisterType<CartonReportsService>().As<ICartonReportsService>();
            builder.RegisterType<SaHoldStoriesReportService>().As<Facade.Services.ISaHoldStoriesReportService>();
            builder.RegisterType<ProductsReportsService>().As<IProductsReportsService>();
            builder.RegisterType<CartonTypeService>().As<IFacadeService<CartonType, string, CartonTypeResource, CartonTypeUpdateResource>>();
            builder.RegisterType<SaCoreTypeService>().As<IFacadeService<SaCoreType, int, SaCoreTypeResource, SaCoreTypeResource>>();
            builder.RegisterType<SernosConfigService>().As<IFacadeService<SernosConfig, string, SernosConfigResource, SernosConfigResource>>();
            builder.RegisterType<TypeOfSaleService>().As<IFacadeService<TypeOfSale, string, TypeOfSaleResource, TypeOfSaleResource>>();
            builder.RegisterType<StockTriggerLevelsService>().As<IStockTriggerLevelsService>();
            builder.RegisterType<SalesArticleForecastService>().As<IFacadeService<SalesArticle, string, SalesArticleResource, SalesArticleResource>>();
            builder.RegisterType<SaHoldStoryService>().As<IFacadeService<SaHoldStory, int, SaHoldStoryResource, SaHoldStoryResource>>();

            // rest client proxies
            builder.RegisterType<RestClient>().As<IRestClient>();
            builder.RegisterType<SalesArticleProxy>().As<ISalesArticleService>().WithParameter("rootUri", ConfigurationManager.Configuration["PROXY_ROOT"]);
            builder.RegisterType<CartonProxy>().As<ICartonRepository>().WithParameter("rootUri", ConfigurationManager.Configuration["PROXY_ROOT"]);
            builder.RegisterType<ProductRangeProxy>().As<IProductRangeRepository>().WithParameter("rootUri", ConfigurationManager.Configuration["PROXY_ROOT"]);
            builder.RegisterType<SalesProductProxy>().As<ISalesProductRepository>().WithParameter("rootUri", ConfigurationManager.Configuration["PROXY_ROOT"]);

            // Oracle proxies
            builder.RegisterType<StockTriggerLevelDataProxy>().As<IStockTriggerLevelDataService>();
        }
    }
}