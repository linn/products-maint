namespace Linn.Products.Domain.Linnapps.Reports
{
    using System;

    using Linn.Common.Reporting.Models;

    public interface IOrdersByNominalReportService
    {
        ResultsModel GetOrdersByNominal(DateTime from, DateTime to, string nominal);
    }
}