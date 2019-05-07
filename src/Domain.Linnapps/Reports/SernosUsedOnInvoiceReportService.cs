namespace Linn.Products.Domain.Linnapps.Reports
{
    using System;
    using System.Data;

    using Linn.Common.Reporting.Models;
    using Linn.Products.Domain.Linnapps.RemoteServices;

    public class SernosUsedOnInvoiceReportService : ISernosUsedOnInvoiceReportService
    {
        private readonly ISernosUsedOnInvoiceDatabaseService databaseService;

        public SernosUsedOnInvoiceReportService(ISernosUsedOnInvoiceDatabaseService databaseService)
        {
            this.databaseService = databaseService;
        }

        public ResultsModel GetReport(int? invoiceNumber, int? consignmentNumber)
        {
            string salesAccount;
            var table = this.databaseService.GetReport(invoiceNumber, consignmentNumber);
            try
            {
                salesAccount = table.Rows[0][0].ToString();
            }
            catch (IndexOutOfRangeException x)
            {
                salesAccount = string.Empty;
            }
            var results = new ResultsModel(new[]
                                               {
                                                   "Invoice Line",
                                                   "Sales Article",
                                                   "Description",
                                                   "Serial #1",
                                                   "Serial #2",
                                                   "Warranty",
                                                   "Order Number",
                                                   "Order Line"
                                               }) {
                                                    ReportTitle = new NameModel(salesAccount)
                                                  };

            foreach (DataRow tableRow in table.Rows)
            {
                var row = results.AddRow(tableRow[10].ToString());
                results.SetGridTextValue(row.RowIndex, 0, tableRow[3]?.ToString());
                results.SetGridTextValue(row.RowIndex, 1, tableRow[6]?.ToString());
                results.SetGridTextValue(row.RowIndex, 2, tableRow[9]?.ToString());
                results.SetGridTextValue(row.RowIndex, 3, tableRow[10]?.ToString());
                results.SetGridTextValue(row.RowIndex, 4, tableRow[11]?.ToString());
                results.SetGridTextValue(row.RowIndex, 5, tableRow[8]?.ToString());
                results.SetGridTextValue(row.RowIndex, 6, tableRow[4]?.ToString());
                results.SetGridTextValue(row.RowIndex, 7, tableRow[5]?.ToString());

            }

            return results;
        }      
    }
}
