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
            var table = this.databaseService.GetReport(invoiceNumber, consignmentNumber);

            if (consignmentNumber == null)
            {
                consignmentNumber = (int)table.Rows[0][1];
            }

            var salesAccount = table.Rows[0][0];
            var results = new ResultsModel(new[]
                                               {
                                                   "Invoice Line",
                                                   "Sales Article",
                                                   "Quantity",
                                                   "Warranty Number",
                                                   "Description",
                                                   "Serial Number 1",
                                                   "Serial Number 2",
                                                   "Order Number",
                                                   "Order Line"
                                               }) {
                                                    ReportTitle = new NameModel($"{invoiceNumber} {consignmentNumber} {salesAccount}")
                                                  };

            foreach (DataRow tableRow in table.Rows)
            {
                var row = results.AddRow(tableRow[10].ToString());
                results.SetGridValue(row.RowIndex, 0, int.Parse(tableRow[3].ToString()));
                results.SetGridValue(row.RowIndex, 1, int.Parse(tableRow[10].ToString()));
                results.SetGridValue(row.RowIndex, 2, tableRow[11] == DBNull.Value ? null  : (int?)int.Parse(tableRow[11].ToString()));
                results.SetGridTextValue(row.RowIndex, 3, tableRow[6].ToString());
                results.SetGridTextValue(row.RowIndex, 4, tableRow[9].ToString());
                results.SetGridValue(row.RowIndex, 5, int.Parse(tableRow[4].ToString()));
                results.SetGridValue(row.RowIndex, 6, int.Parse(tableRow[5].ToString()));
            }

            return results;
        }      
    }
}
