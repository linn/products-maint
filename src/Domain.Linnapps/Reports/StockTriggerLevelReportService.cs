namespace Linn.Products.Domain.Linnapps.Reports
{
    using System;
    using System.Collections.Generic;
    using System.Data;

    using Linn.Products.Domain.Linnapps.ReportModels;
    using Linn.Common.Configuration;

    using Oracle.ManagedDataAccess.Client;

    public class StockTriggerLevelReportService : IStockTriggerLevelReportService
    {
        public static int? NullOrNumber(object obj)
        {
            if (obj == DBNull.Value)
            {
                return null;
            }
            return int.Parse(obj.ToString());
        }

        public IEnumerable<StockTriggerLevelReport> GetStockTriggerLevelReportAtLocation(int locationId)
        {
            var host = ConfigurationManager.Configuration["DATABASE_HOST"];
            var userId = ConfigurationManager.Configuration["DATABASE_USER_ID"];
            var password = ConfigurationManager.Configuration["DATABASE_PASSWORD"];

            var connection = new OracleConnection($"User Id = {userId}; Password = {password}; Data Source = {host};");

            string sql =
           $@"select stl.stl_id, stl.part_number, stl.trigger_level, stl.maximum_capacity,
            nvl(st.qty, 0) qty_at_location,
            st.state, sl.pallet_number, 
            l.location_code,
            sl.qty qty_available, sl.qty_allocated, sl.stock_rotation_date
            from stock_trigger_levels stl, stock_locators sl, storage_locations l,
            work_station_elements wse1, work_station_elements wse2,
            stock_at_location_view st
            where stl.location_id = {locationId}
            and nvl(st.location_id (+), -1) = nvl(stl.location_id, -1)
            and nvl(st.pallet_number (+), -1) = nvl(stl.pallet_number, -1)
            and sl.location_id = l.location_id(+)
            and sl.part_number = stl.part_number
            and not(nvl(sl.location_id, -1) = nvl(stl.location_id, -1) and nvl(sl.pallet_number, -1) = nvl(stl.pallet_number, -1))
            and sl.current_stock = 'Y'
            and sl.qty > 0
            and sl.state = 'STORES'
            and nvl(st.qty, 0) <= stl.trigger_level
            and nvl(wse2.work_station_code, wse1.work_station_code) is null
            and wse1.pallet_number(+) = sl.pallet_number
            and wse2.location_id(+) = sl.location_id
            order by stl.part_number, sl.stock_rotation_date";

            var cmd = new OracleCommand(sql, connection) { CommandType = CommandType.Text};
            var reportValues = new List<StockTriggerLevelReport>();

            var dataAdapter = new OracleDataAdapter(cmd);
            var dataSet = new DataSet();
            dataAdapter.Fill(dataSet);

            var table = dataSet.Tables[0];

            foreach (DataRow tableRow in table.Rows)
            { 
                reportValues.Add(
                    new StockTriggerLevelReport()
                        {
                            PartNumber = tableRow[1].ToString(),
                            TriggerLevel = NullOrNumber(tableRow[2]),
                            MaxCapacity = NullOrNumber(tableRow[3]),
                            QtyAtLocation = NullOrNumber(tableRow[4]),
                            PalletNumber = NullOrNumber(tableRow[6]),
                            LocationCode = tableRow[7] == DBNull.Value ? null : tableRow[7].ToString(),
                            QtyAvailable = NullOrNumber(tableRow[8]),
                            QtyAllocated = NullOrNumber(tableRow[9]),
                            StockRotationDate = DateTime.Parse(tableRow[10].ToString())
                        });
            }
            return reportValues;
        }
    }
}
