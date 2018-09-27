namespace Linn.Products.Domain.Reports
{
    using Linn.Common.Reporting.Models;

    public interface ICartonDetailsReportService
    {
        ResultsModel GetCartonsReport();
    }
}
