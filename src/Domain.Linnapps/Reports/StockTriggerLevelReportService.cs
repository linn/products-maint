namespace Linn.Products.Domain.Linnapps.Reports
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    using Linn.Common.Reporting.Models;

    public class StockTriggerLevelReportService : IStockTriggerLevelReportService
    {
        private RemoteServices.IStockTriggerLevelReportService databaseService;

        public StockTriggerLevelReportService(RemoteServices.IStockTriggerLevelReportService service)
        {
            this.databaseService = service;
        }

        public ResultsModel GetStockTriggerLevelReportForPartAtLocation(int locationId, string partNumber)
        {
            var table = this.databaseService.GetStockTriggerLevelsForPartAtLocation(locationId, partNumber);
            var results = new ResultsModel(new[] {"Pallet Number", "Location Code", "Qty Available", "Qty Allocated", "Stock Rotation Date"})
                              {
                                  ReportTitle = new NameModel($"Stock Trigger Levels for Part {partNumber} at Location {locationId}")
                              };

            results.SetColumnType(0, GridDisplayType.Value);
            results.SetColumnType(1, GridDisplayType.TextValue);
            results.SetColumnType(2, GridDisplayType.Value);
            results.SetColumnType(3, GridDisplayType.Value);
            results.SetColumnType(4, GridDisplayType.TextValue);
            var rowId = 0;

            foreach (DataRow tableRow in table.Rows)
            {
                var row = results.AddRow((rowId++).ToString());

                results.SetGridValue(row.RowIndex, 0, NullOrNumber(tableRow[1]));
                results.SetGridTextValue(row.RowIndex, 1, tableRow[3] == DBNull.Value ? null : tableRow[3].ToString());
                results.SetGridValue(row.RowIndex, 2, NullOrNumber(tableRow[4]));
                results.SetGridValue(row.RowIndex, 3, NullOrNumber(tableRow[5]));
                results.SetGridTextValue(row.RowIndex, 4, tableRow[6] == DBNull.Value ? null : tableRow[6].ToString()); 
            }

            return results; 
        }

        public ResultsModel GetPartDataAtLocation(int locationId)
        {
            var table = this.databaseService.GetPartDataAtLocation(locationId);
            var results = new ResultsModel(new[] { "Trigger Level", "Max Capacity", "Qty At Location" })
                              {
                                  ReportTitle = new NameModel($"Stock Trigger Levels at Location {locationId}")
                              };

            results.SetColumnType(0, GridDisplayType.TextValue);
            results.SetColumnType(1, GridDisplayType.Value);
            results.SetColumnType(2, GridDisplayType.Value);
         
            foreach (DataRow tableRow in table.Rows)
            {
                var row = results.AddRow(tableRow[1].ToString().Replace("/", "%2F"), tableRow[1].ToString()); 
                results.SetGridValue(row.RowIndex, 0, NullOrNumber(tableRow[2]));
                results.SetGridValue(row.RowIndex, 1, NullOrNumber(tableRow[3]));
                results.SetGridValue(row.RowIndex, 2, NullOrNumber(tableRow[6]));
            }

            results.RowDrillDownTemplates.Add(new DrillDownModel("name", $"/products/reports/stock-trigger-levels/{locationId}/" + "{rowId}"));
           
            return results;
        }

        private static int? NullOrNumber(object obj)
        {
            if (obj == DBNull.Value)
            {
                return null;
            }

            return int.Parse(obj.ToString());
        }
    }
}
