namespace Linn.Products.Domain.Linnapps.Reports
{
    using Linn.Common.Reporting.Models;

    public interface IEanCodeReportService
    {
        ResultsModel GetEanCodeReport(bool includePhasedOut = false, bool cartonisedOnly = false);
    }
}
