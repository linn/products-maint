namespace Linn.Products.Service.Modules
{

    using Nancy;

    using IStockTriggerLevelReportService = Linn.Products.Domain.Linnapps.Reports.IStockTriggerLevelReportService;

    public sealed class StockTriggerLevelReportModule : NancyModule
    {
        private readonly IStockTriggerLevelReportService stockTriggerLevelReportService;

        public StockTriggerLevelReportModule(IStockTriggerLevelReportService stockTriggerLevelReportService)
        {
            this.stockTriggerLevelReportService = stockTriggerLevelReportService;
            this.Get("/products/reports/stock-trigger-levels/{locationId}", parameters => this.GetStockTriggerLevelsAtLocation(parameters.locationId));
        }

        private object GetStockTriggerLevelsAtLocation(int locationId)
        {
            var results = this.stockTriggerLevelReportService.GetStockTriggerLevelReportAtLocation(locationId);
            return this.Negotiate.WithModel(results);
        }
    }
}