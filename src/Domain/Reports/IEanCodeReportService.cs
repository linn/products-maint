namespace Linn.Products.Domain.Reports
{
    using Linn.Common.Reporting.Models;

    public interface IEanCodeReportService
    {
        ResultsModel GetEanCodeReport(bool includePhasedOut = false, bool cartonisedOnly = false);
    }
}
