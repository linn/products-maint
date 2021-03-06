﻿namespace Linn.Products.Facade.Services
{
    using Linn.Common.Facade;
    using Linn.Common.Reporting.Models;
    using Linn.Products.Domain.Linnapps.Reports;

    public class StockTriggerLevelsService : IStockTriggerLevelsService
    {
        private readonly IStockTriggerLevelReportService stockTriggerLevelsService;

        public StockTriggerLevelsService(IStockTriggerLevelReportService stockTriggerLevelsService)
        {
            this.stockTriggerLevelsService = stockTriggerLevelsService;
        }

        public IResult<ResultsModel> GetStockTriggerLevelsForPartAtLocation(int locationId, string partNumber)
        {
            var results = this.stockTriggerLevelsService.GetStockTriggerLevelReportForPartAtLocation(locationId, partNumber);
            return new SuccessResult<ResultsModel>(results);
        }

        public IResult<ResultsModel> GetPartDataAtLocation(int locationId)
        {
            var results = this.stockTriggerLevelsService.GetPartDataAtLocation(locationId);
            return new SuccessResult<ResultsModel>(results);
        }
    }
}