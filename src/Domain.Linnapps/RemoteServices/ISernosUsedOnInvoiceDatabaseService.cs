namespace Linn.Products.Domain.Linnapps.RemoteServices
{
    using System.Data;

    public interface ISernosUsedOnInvoiceDatabaseService
    {
        DataTable GetReport(int? invoiceNumber, int? consignmentNumber);
    }
}