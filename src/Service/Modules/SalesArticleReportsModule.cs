namespace Linn.Products.Service.Modules
{
    using Linn.Products.Facade.Services;
    using Linn.Products.Service.Models;

    using Nancy;

    public sealed class SalesArticleReportsModule : NancyModule
    {
        private readonly ISalesArticleReportService salesArticleReportService;

        public SalesArticleReportsModule(ISalesArticleReportService salesArticleReportService)
        {
            this.salesArticleReportService = salesArticleReportService;

            this.Get("/products/reports/sales-article-ean-codes", _ => this.GetSalesArticlesByEanCode());
            this.Get("/products/reports/sales-article-ean-codes/export", _ => this.GetSalesArticlesByEanCodeExport());
        }

        private object GetSalesArticlesByEanCode()
        {
            var results = this.salesArticleReportService.GetEanCodeResults();

            return this.Negotiate
                .WithModel(results)
                .WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }

        private object GetSalesArticlesByEanCodeExport()
        {
            var results = this.salesArticleReportService.GetEanCodeCsvResults();

            return this.Negotiate
                .WithModel(results)
                .WithAllowedMediaRange("text/csv")
                .WithView("Index");
        }
    }
}