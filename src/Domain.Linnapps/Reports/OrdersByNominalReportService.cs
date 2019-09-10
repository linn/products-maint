namespace Linn.Products.Domain.Linnapps.Reports
{
    using System;
    using System.Data;

    using Linn.Common.Reporting.Models;
    using Linn.Products.Domain.Linnapps.RemoteServices;

    public class OrdersByNominalReportService : IOrdersByNominalReportService
    {
        private readonly IOrdersByNominalDatabaseService databaseService;

        public OrdersByNominalReportService(IOrdersByNominalDatabaseService databaseService)
        {
            this.databaseService = databaseService;
        }

        public ResultsModel GetOrdersByNominal(DateTime from, DateTime to, string nominal)
        {
            var results =
                new ResultsModel(
                    new[] { "Order Number", "Order Line", "Part Number", "Supplier Designation", "Qty Ord", "Qty Inv", "Total (GBP), Outst(GBP)" })
                    {
                        ReportTitle = new NameModel("Orders By Nominal")
                    };

            var table = this.databaseService.GetDataTable(from, to, nominal);

            foreach (DataRow tableRow in table.Rows)
            {
                var row = results.AddRow(tableRow[0].ToString());
                results.SetGridTextValue(row.RowIndex, 0, tableRow[0].ToString());
                results.SetGridTextValue(row.RowIndex, 1, tableRow[1].ToString());
                results.SetGridTextValue(row.RowIndex, 2, tableRow[2].ToString());
                results.SetGridTextValue(row.RowIndex, 3, tableRow[3].ToString());
                results.SetGridTextValue(row.RowIndex, 4, tableRow[4].ToString());
                results.SetGridTextValue(row.RowIndex, 5, tableRow[5].ToString());
                results.SetGridTextValue(row.RowIndex, 6, tableRow[6].ToString());
                results.SetGridTextValue(row.RowIndex, 7, tableRow[7].ToString());
            }

            return results;
        }
    }
}