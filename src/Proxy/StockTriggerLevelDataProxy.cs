namespace Linn.Products.Proxy
{
    using System;
    using System.Data;

    using Linn.Common.Configuration;
    using Linn.Products.Domain.Linnapps.RemoteServices;
    using Oracle.ManagedDataAccess.Client;

    public class StockTriggerLevelDataProxy : IStockTriggerLevelDataService
    {
        private readonly string host = ConfigurationManager.Configuration["DATABASE_HOST"];
        private readonly string userId = ConfigurationManager.Configuration["DATABASE_USER_ID"];
        private readonly string password = ConfigurationManager.Configuration["DATABASE_PASSWORD"];

        private readonly string databaseName = ConfigurationManager.Configuration["DATABASE_NAME"];

        public DataTable GetStockTriggerLevelsForPartAtLocation(int locationId, string partNumber)
        {
            var sql =
            $@"select sl.part_number,
            sl.pallet_number, sl.location_id, l.location_code,
            sl.qty qty_available, sl.qty_allocated, sl.stock_rotation_date,
            nvl(wse2.work_station_code, wse1.work_station_code) work_station_code
            from stock_locators sl, storage_locations l,
            work_station_elements wse1, work_station_elements wse2
            where sl.location_id = l.location_id (+)
            and sl.part_number = '{partNumber}'
            and not (nvl(sl.location_id, -1) = nvl({locationId}, -1) 
            and sl.pallet_number is null)
            and sl.current_stock = 'Y'
            and sl.qty > 0
            and sl.state = 'STORES'
            and nvl(wse2.work_station_code, wse1.work_station_code) is null
            and wse1.pallet_number (+) = sl.pallet_number
            and wse2.location_id (+) = sl.location_id
            order by sl.part_number, sl.stock_rotation_date";

            var cmd = new OracleCommand(sql, this.getConnection()) { CommandType = CommandType.Text };
            var dataAdapter = new OracleDataAdapter(cmd);
            var dataSet = new DataSet();

            dataAdapter.Fill(dataSet);

            return dataSet.Tables[0];
        }

        public DataTable GetPartDataAtLocation(int locationId)
        {
            var sql =
               $@"select stl.stl_id, stl.part_number, stl.trigger_level, stl.maximum_capacity,
            stl.location_id, stl.pallet_number,
            nvl(st.qty, 0) qty_at_location
            from stock_trigger_levels stl, stock_at_location_view st
            where stl.location_id = {locationId}
            and st.part_number(+) = stl.part_number
            and nvl(st.location_id (+), -1) = nvl(stl.location_id, -1)
            and nvl(st.pallet_number (+), -1) = nvl(stl.pallet_number, -1)
            and nvl(st.qty, 0) <= stl.trigger_level
            order by stl.part_number";

            var cmd = new OracleCommand(sql, this.getConnection()) { CommandType = CommandType.Text };
            var dataAdapter = new OracleDataAdapter(cmd);
            var dataSet = new DataSet();

            dataAdapter.Fill(dataSet);

            return dataSet.Tables[0];
        }

        public int GetQtyAvailableAtEk2Location(string partNumber)
        {
            var sql = $@"select sum(QTY_AVAILABLE) FROM (select sl.part_number,
            sl.pallet_number, sl.location_id, l.location_code,
            sl.qty qty_available, sl.qty_allocated, sl.stock_rotation_date,
            nvl(wse2.work_station_code, wse1.work_station_code) work_station_code
                from stock_locators sl, storage_locations l,
            work_station_elements wse1, work_station_elements wse2
                where sl.location_id = l.location_id(+)
            and sl.part_number = '{partNumber}'
            and not(nvl(sl.location_id, -1) = nvl(18104, -1)
            and sl.pallet_number is null)
            and sl.current_stock = 'Y'
            and sl.qty > 0
            and l.location_code LIKE '%E-K2%'
            and sl.state = 'STORES'
            and nvl(wse2.work_station_code, wse1.work_station_code) is null
            and wse1.pallet_number(+) = sl.pallet_number
            and wse2.location_id(+) = sl.location_id
            order by sl.part_number, sl.stock_rotation_date)";

            var cmd = new OracleCommand(sql, this.getConnection()) { CommandType = CommandType.Text };
            var dataAdapter = new OracleDataAdapter(cmd);
            var dataSet = new DataSet();

            dataAdapter.Fill(dataSet);

            var result = dataSet.Tables[0];
            var response = result.Rows[0].ItemArray[0];
            return int.TryParse(response?.ToString(), out var returnValue) ? returnValue : 0;
        }

        private OracleConnection getConnection()
        {
            var dataSource = $"(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST={host})(PORT=1521))(CONNECT_DATA=(SERVICE_NAME={this.databaseName})(SERVER=dedicated)))";
            var connection = new OracleConnection($"Data Source={dataSource};User Id={userId};Password={password};");
            return connection;
        }
    }
}
