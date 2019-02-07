namespace Linn.Products.Service.Reports
{
    using Linn.Products.Facade.Services;
    using Linn.Products.Service.Models;

    using Nancy;

    public sealed class StockTriggerLevelReportModule : NancyModule
    {
        private readonly IStockTriggerLevelsService stockTriggerLevelsService;

        public StockTriggerLevelReportModule(IStockTriggerLevelsService stockTriggerLevelsService)
        {
            this.stockTriggerLevelsService = stockTriggerLevelsService;
            this.Get("/products/reports/stock-trigger-levels/{locationId}/{partNumber*}", parameters => this.GetStockTriggerLevelsAtLocation(parameters.locationId, parameters.partNumber));
            this.Get("/products/reports/parts-at-location/{locationId}", parameters => this.GetPartDataAtLocation(parameters.locationId));
        }

        private object GetStockTriggerLevelsAtLocation(int locationId, string partNumber)
        {
            var results =
                this.stockTriggerLevelsService.GetStockTriggerLevelsForPartAtLocation(locationId, partNumber);
            return this.Negotiate.WithModel(results).WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }

        private object GetPartDataAtLocation(int locationId)
        {
            var results = this.stockTriggerLevelsService.GetPartDataAtLocation(locationId);
            return this.Negotiate.WithModel(results).WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }
    }
}