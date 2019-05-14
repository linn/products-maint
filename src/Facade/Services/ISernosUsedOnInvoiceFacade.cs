namespace Linn.Products.Facade.Services
{
    using Linn.Common.Facade;
    using Linn.Common.Reporting.Models;

    public interface ISernosUsedOnInvoiceFacade
    {
        IResult<ResultsModel> GetReport(int? invoiceNumber, int? consignmentNumber);
    }
}
