namespace Linn.Products.Facade.Services
{
    using System.Collections.Generic;

    using Linn.Common.Facade;
    using Linn.Common.Reporting.Models;
    using Linn.Products.Domain.Reports;

    public class StockTriggerLevelReportService : IStockTriggerLevelReportService
    {
        private readonly Domain.Linnapps.Reports.IStockTriggerLevelReportService stockTriggerLevelReportService;

        public StockTriggerLevelReportService(Domain.Linnapps.Reports.IStockTriggerLevelReportService stockTriggerLevelReportService)
        {
            this.stockTriggerLevelReportService = stockTriggerLevelReportService;
        }

        public IResult<ResultsModel> GetStockTriggerLevelsForPartAtLocation(int locationId, string partNumber)
        {
            var results = this.stockTriggerLevelReportService.GetStockTriggerLevelReportForPartAtLocation(locationId, partNumber);
            return new SuccessResult<ResultsModel>(results);
        }

        public IResult<ResultsModel> GetPartDataAtLocation(int locationId)
        {
            var results = this.stockTriggerLevelReportService.GetPartDataAtLocation(locationId);
            return new SuccessResult<ResultsModel>(results);
        }
    }
}