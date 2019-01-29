namespace Linn.Products.Facade.Services
{
    using Linn.Common.Facade;
    using Linn.Common.Reporting.Models;
    using Linn.Products.Domain.Linnapps.Reports;

    public class StockTriggerLevelReportService : IStockTriggerLevelsService
    {
        private readonly IStockTriggerLevelReportService stockTriggerLevelsService;

        public StockTriggerLevelReportService(Domain.Linnapps.Reports.IStockTriggerLevelReportService stockTriggerLevelsService)
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