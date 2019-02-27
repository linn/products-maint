namespace Linn.Products.Service.Modules
{
    using Linn.Products.Facade.Services;
    using Linn.Products.Resources;
    using Linn.Products.Service.Models;

    using Nancy;
    using Nancy.ModelBinding;
    using Nancy.Security;

    public sealed class SalesArticleReportsModule : NancyModule
    {
        private readonly ISalesArticleReportService salesArticleReportService;

        public SalesArticleReportsModule(ISalesArticleReportService salesArticleReportService)
        {
            this.salesArticleReportService = salesArticleReportService;

            this.Get("/products/reports/sales-article-ean-codes", _ => this.GetSalesArticlesByEanCode());
            this.Get("/products/reports/sales-article-ean-codes/export", _ => this.GetSalesArticlesByEanCodeExport());
            this.Get("/products/reports/sales-article-core-types", _ => this.GetSalesArticlesCoreTypeReport());
            this.Get("/products/reports/sales-article-core-types/export", _ => this.GetSalesArticlesCoreTypeReportExport());
        }

        private object GetSalesArticlesByEanCode()
        {
            this.RequiresAuthentication();
            var resource = this.Bind<EanCodesReportRequestResource>();
            var results = this.salesArticleReportService.GetEanCodeResults(
                resource.IncludePhasedOut,
                resource.CartonisedOnly);

            return this.Negotiate
                .WithModel(results)
                .WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }

        private object GetSalesArticlesByEanCodeExport()
        {
            this.RequiresAuthentication();
            var resource = this.Bind<EanCodesReportRequestResource>();
            var results = this.salesArticleReportService.GetEanCodeCsvResults(
                resource.IncludePhasedOut,
                resource.CartonisedOnly);

            return this.Negotiate
                .WithModel(results)
                .WithAllowedMediaRange("text/csv")
                .WithView("Index");
        }

        private object GetSalesArticlesCoreTypeReport()
        {
            var results = this.salesArticleReportService.GetSalesArticleCoreTypes();

            return this.Negotiate
                .WithModel(results)
                .WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }

        private object GetSalesArticlesCoreTypeReportExport()
        {
            this.RequiresAuthentication();
            var results = this.salesArticleReportService.GetSalesArticleCoreTypesCsv();

            return this.Negotiate
                .WithModel(results)
                .WithAllowedMediaRange("text/csv")
                .WithView("Index");
        }
    }
}