namespace Linn.Products.Domain.Linnapps.Reports
{
    using Linn.Common.Reporting.Models;

    public interface IStockTriggerLevelReportService
    {
        ResultsModel GetStockTriggerLevelReportForPartAtLocation(int locationId, string partNumber);

        ResultsModel GetPartDataAtLocation(int locationId);
    }
}