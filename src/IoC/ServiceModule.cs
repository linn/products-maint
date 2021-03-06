﻿namespace Linn.Products.IoC
{
    using System.Data;
    using Autofac;
    using Linn.Common.Configuration;
    using Linn.Common.Facade;
    using Linn.Common.Proxy;
    using Linn.Common.Reporting.Models;
    using Linn.Products.Domain;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Domain.Linnapps.RemoteServices;
    using Linn.Products.Domain.Linnapps.Reports;
    using Linn.Products.Domain.Linnapps.SalesPackages;
    using Linn.Products.Domain.Linnapps.SernosTransactions;
    using Linn.Products.Domain.Reports;
    using Linn.Products.Domain.Repositories;
    using Linn.Products.Facade;
    using Linn.Products.Facade.Services;
    using Linn.Products.Proxy;
    using Linn.Products.Resources;
    using Oracle.ManagedDataAccess.Client;
    using ProductRange = Linn.Products.Domain.Linnapps.Products.ProductRange;

    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // domain services
            builder.RegisterType<EanCodeReportService>().As<IEanCodeReportService>();
            builder.RegisterType<CartonDetailsReportService>().As<ICartonDetailsReportService>();
            builder.RegisterType<ProductReports>().As<IProductReports>();
            builder.RegisterType<StockTriggerLevelReportService>().As<IStockTriggerLevelReportService>();
            builder.RegisterType<SernosUsedOnInvoiceReportService>().As<ISernosUsedOnInvoiceReportService>();
            builder.RegisterType<SaHoldStoryService>().As<ISaHoldStoryService>();
            builder.RegisterType<SalesArticleReports>().As<ISalesArticleReports>();
            builder.RegisterType<ProductsOnHoldService>().As<IProductsOnHoldService>();
            builder.RegisterType<SerialNumberFactory>().As<ISerialNumberFactory>();
            builder.RegisterType<AuthorisationService>().As<IAuthorisationService>();
            builder.RegisterType<WEEEReports>().As<IWEEEReports>();

            // facade services
            builder.RegisterType<SalesArticleReportService>().As<ISalesArticleReportService>();
            builder.RegisterType<TariffService>().As<ITariffFacadeService>();
            builder.RegisterType<CartonReportsService>().As<ICartonReportsService>();
            builder.RegisterType<SaHoldStoryReportService>().As<ISaHoldStoriesReportService>();
            builder.RegisterType<ProductsReportsService>().As<IProductsReportsService>();
            builder.RegisterType<CartonTypeService>().As<IFacadeService<CartonType, string, CartonTypeResource, CartonTypeUpdateResource>>();
            builder.RegisterType<SaCoreTypeService>().As<IFacadeService<SaCoreType, int, SaCoreTypeResource, SaCoreTypeResource>>();
            builder.RegisterType<SernosConfigService>().As<IFacadeService<SernosConfig, string, SernosConfigResource, SernosConfigResource>>();
            builder.RegisterType<SernosSequenceService>().As<IFacadeService<SernosSequence, string, SernosSequenceResource, SernosSequenceResource>>();
            builder.RegisterType<TypeOfSaleService>().As<IFacadeService<TypeOfSale, string, TypeOfSaleResource, TypeOfSaleResource>>();
            builder.RegisterType<StockTriggerLevelsService>().As<IStockTriggerLevelsService>();
            builder.RegisterType<SaHoldStoryFacadeService>().As<IFacadeService<SaHoldStory, int, SaHoldStoryResource, SaHoldStoryResource>>();
            builder.RegisterType<ProductsOnHoldReportService>().As<IProductsOnHoldReportService>();
            builder.RegisterType<SernosUsedOnInvoiceFacade>().As<ISernosUsedOnInvoiceFacade>();
            builder.RegisterType<WEEEReportsService>().As<IWEEEReportsService>();

            builder.RegisterType<SaHoldStoryFacadeService>().As<IFacadeService<SaHoldStory, int, SaHoldStoryResource, SaHoldStoryResource>>();
            builder.RegisterType<SalesArticleService>().As<IFacadeService<SalesArticle, string, SalesArticleResource, SalesArticleResource>>();
            builder.RegisterType<VatCodeService>().As<IFacadeService<VatCode, string, VatCodeResource, VatCodeResource>>();
            builder.RegisterType<ProductRangeService>().As<IFacadeService<ProductRange, int, ProductRangeResource, ProductRangeUpdateResource>>();
            builder.RegisterType<SalesPackageService>().As<IFacadeService<SalesPackage, int, SalesPackageResource, SalesPackageResource>>();
            builder.RegisterType<RootProductService>()
                .As<IFacadeService<RootProduct, string, RootProductResource, RootProductResource>>();
            builder.RegisterType<SalesArticleCompositeDiscountFacadeService>().As<ISalesArticleCompositeDiscountFacadeService>();
            builder.RegisterType<SerialNumberService>().As<ISerialNumberFacadeService>();
            builder.RegisterType<SernosNoteService>().As<IFacadeService<SernosNote, int, SernosNoteCreateResource, SernosNoteResource>>();
            builder.RegisterType<SernosTransactionService>().As<IFacadeService<SernosTrans, string, SernosTransactionResource, SernosTransactionResource>>();
            builder.RegisterType<SernosCountService>().As<IFacadeService<SernosCount, string, SernosCountResource, SernosCountResource>>();
            builder.RegisterType<SalesArticleSerialNumberFacadeService>().As<ISalesArticleSerialNumberFacadeService>();
            builder.RegisterType<ArchiveSerialNumberService>().As<IArchiveSerialNumberFacadeService>();

            // rest client proxies
            builder.RegisterType<RestClient>().As<IRestClient>();
            builder.RegisterType<SalesArticleProxy>().As<ISalesArticleService>().WithParameter("rootUri", ConfigurationManager.Configuration["PROXY_ROOT"]);
            builder.RegisterType<CartonProxy>().As<ICartonRepository>().WithParameter("rootUri", ConfigurationManager.Configuration["PROXY_ROOT"]);
            builder.RegisterType<ProductRangeProxy>().As<IProductRangeRepository>().WithParameter("rootUri", ConfigurationManager.Configuration["PROXY_ROOT"]);
            builder.RegisterType<SalesProductProxy>().As<ISalesProductRepository>().WithParameter("rootUri", ConfigurationManager.Configuration["PROXY_ROOT"]);
            builder.RegisterType<SalesPartProxy>().As<ISalesPartRepository>().WithParameter("rootUri", ConfigurationManager.Configuration["PROXY_ROOT"]);
            builder.RegisterType<ProductionTriggerLevelsProxyService>().As<IProductionTriggerLevelsService>().WithParameter("rootUri", ConfigurationManager.Configuration["PROXY_ROOT"]);

            // Oracle proxies
            builder.RegisterType<StockTriggerLevelDataProxy>().As<IStockTriggerLevelDataService>();
            builder.RegisterType<DatabaseProxy>().As<IDatabaseService>();
            builder.RegisterType<SalesArticleCompositeDiscountProxyService>().As<ISalesArticleCompositeDiscountService>();
            builder.RegisterType<SernosPack>().As<ISernosPack>();
            builder.RegisterType<SernosUsedOnInvoiceReportProxy>().As<ISernosUsedOnInvoiceDatabaseService>();

            builder.RegisterType<OracleConnection>().As<IDbConnection>().WithParameter("connectionString", ConnectionStrings.ManagedConnectionString());
            builder.RegisterType<OracleCommand>().As<IDbCommand>();
            builder.RegisterType<OracleDataAdapter>().As<IDataAdapter>();

            // common services
            builder.RegisterType<ReportingHelper>().As<IReportingHelper>();
        }
    }
}
