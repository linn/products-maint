namespace Linn.Products.Domain.Reports
{
    using System;
    using System.Collections.Generic;

    using Linn.Common.Reporting.Models;

    public interface IWEEEReports
    {
        IEnumerable<ResultsModel> GetUkWEEEReport(DateTime fromDate, DateTime toDate);

        IEnumerable<ResultsModel> GetGermanWeeeReport(DateTime fromDate, DateTime toDate);
    }
}
