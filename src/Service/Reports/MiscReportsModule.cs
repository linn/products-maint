namespace Linn.Products.Service.Reports
{
    using System;

    using Linn.Products.Facade.Services;
    using Linn.Products.Service.Models;

    using Nancy;

    public sealed class MiscReportsModule : NancyModule
    {
        private readonly IStockTriggerLevelsService stockTriggerLevelsService;

        private readonly IOrdersByNominalService ordersByNominalService;

        public MiscReportsModule(IStockTriggerLevelsService stockTriggerLevelsService, IOrdersByNominalService ordersByNominalService)
        {
            this.stockTriggerLevelsService = stockTriggerLevelsService;
            this.ordersByNominalService = ordersByNominalService;
            this.Get(
                "/products/reports/stock-trigger-levels/{locationId}/{partNumber*}",
                parameters => this.GetStockTriggerLevelsAtLocation(parameters.locationId, parameters.partNumber));
            this.Get(
                "/products/reports/parts-at-location/{locationId}",
                parameters => this.GetPartDataAtLocation(parameters.locationId));
            this.Get("/products/reports/orders-by-nominal", _ => this.GetOrdersByNominal());
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

        private object GetOrdersByNominal()
        {
            var results = this.ordersByNominalService.GetOrdersByNominalReport(
                new DateTime(2006, 08, 02),
                new DateTime(2006, 09, 02));

            return this.Negotiate.WithModel(results).WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }
    }
}