namespace Linn.Products.Domain.Reports
{
    using System;

    using Linn.Common.Reporting.Models;

    public interface IWEEEReports
    {
        ResultsModel GetUKWEEEReport(DateTime fromDate, DateTime toDate);
    }
}
