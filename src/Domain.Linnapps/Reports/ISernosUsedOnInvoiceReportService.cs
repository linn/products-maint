namespace Linn.Products.Domain.Linnapps.Reports
{
    using Linn.Common.Reporting.Models;

    public interface ISernosUsedOnInvoiceReportService
    {
        ResultsModel GetReport(int? invoiceNumber, int? consignmentNumber);
    }
}