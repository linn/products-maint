﻿namespace Linn.Products.Domain.Linnapps.Reports
{
    using System.Collections.Generic;

    using Linn.Common.Reporting.Models;
    using Linn.Products.Domain.Linnapps.ReportModels;

    public interface IStockTriggerLevelReportService
    {
        IEnumerable<StockTriggerLevelReport> GetStockTriggerLevelReportAtLocation(int locationId);
    }
}