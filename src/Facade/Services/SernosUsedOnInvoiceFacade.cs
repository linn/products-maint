namespace Linn.Products.Facade.Services
{
    using Linn.Common.Facade;
    using Linn.Common.Reporting.Models;
    using Linn.Products.Domain.Linnapps.Reports;

    public class SernosUsedOnInvoiceFacade : ISernosUsedOnInvoiceFacade
    {
        private readonly ISernosUsedOnInvoiceReportService service;

        public SernosUsedOnInvoiceFacade(ISernosUsedOnInvoiceReportService service)
        {
            this.service = service;
        }

        public IResult<ResultsModel> GetReport(int? invoiceNumber, int? consignmentNumber)
        {
            if (invoiceNumber == null && consignmentNumber == null)
            {
                return new BadRequestResult<ResultsModel>("invoiceNumber or consignmentNumber must be specified");
            }
            var results = this.service.GetReport(invoiceNumber, consignmentNumber);
            return new SuccessResult<ResultsModel>(results);
        }
    }
}
