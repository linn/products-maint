namespace Linn.Products.Service.Modules
{
    using Linn.Products.Facade.Services;

    using Nancy;

    public sealed class StockTriggerLevelReportModule : NancyModule
    {
        private readonly IStockTriggerLevelsService stockTriggerLevelsService;

        public StockTriggerLevelReportModule(Facade.Services.IStockTriggerLevelsService stockTriggerLevelsService)
        {
            this.stockTriggerLevelsService = stockTriggerLevelsService;
            this.Get("/products/reports/stock-trigger-levels/{locationId}/{partNumber*}", parameters => this.GetStockTriggerLevelsAtLocation(parameters.locationId, parameters.partNumber));
            this.Get("/products/reports/parts-at-location/{locationId}", parameters => this.GetPartDataAtLocation(parameters.locationId));
        }

        private object GetStockTriggerLevelsAtLocation(int locationId, string partNumber)
        {
            var results =
                this.stockTriggerLevelsService.GetStockTriggerLevelsForPartAtLocation(locationId, partNumber);
            return this.Negotiate.WithModel(results);
        }

        private object GetPartDataAtLocation(int locationId)
        {
            var results = this.stockTriggerLevelsService.GetPartDataAtLocation(locationId);
            return this.Negotiate.WithModel(results);
        }
    }
}