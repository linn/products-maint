namespace Linn.Products.Service.Modules
{

    using Nancy;

    using IStockTriggerLevelReportService = Linn.Products.Domain.Linnapps.Reports.IStockTriggerLevelReportService;

    public sealed class StockTriggerLevelReportModule : NancyModule
    {
        private readonly Facade.Services.IStockTriggerLevelReportService stockTriggerLevelReportService;

        public StockTriggerLevelReportModule(Facade.Services.IStockTriggerLevelReportService stockTriggerLevelReportService)
        {
            this.stockTriggerLevelReportService = stockTriggerLevelReportService;
            this.Get("/products/reports/stock-trigger-levels/{locationId}/{partNumber}", parameters => this.GetStockTriggerLevelsAtLocation(parameters.locationId, parameters.partNumber));
            this.Get("/products/reports/parts-at-location/{locationId}", parameters => this.GetPartDataAtLocation(parameters.locationId));
        }

        private object GetStockTriggerLevelsAtLocation(int locationId, string partNumber)
        {
            var results =
                this.stockTriggerLevelReportService.GetStockTriggerLevelsForPartAtLocation(locationId, partNumber);
            return this.Negotiate.WithModel(results);
        }

        private object GetPartDataAtLocation(int locationId)
        {
            var results = this.stockTriggerLevelReportService.GetPartDataAtLocation(locationId);
            return this.Negotiate.WithModel(results);
        }
    }
}