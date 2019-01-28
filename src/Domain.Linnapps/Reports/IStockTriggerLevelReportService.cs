namespace Linn.Products.Domain.Linnapps.Reports
{
    using System.Collections.Generic;

    using Linn.Common.Reporting.Models;

    public interface IStockTriggerLevelReportService
    {
        ResultsModel GetStockTriggerLevelReportForPartAtLocation(int locationId, string partNumber);

        ResultsModel GetPartDataAtLocation(int locationId);
    }
}