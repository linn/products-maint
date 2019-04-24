namespace Linn.Products.Proxy
{
    using System.Data;

    using Linn.Products.Domain.Linnapps.RemoteServices;

    using Oracle.ManagedDataAccess.Client;

    public class SernosPack : ISernosPack
    {
        public string GetProductGroup(string partNumber)
        {
            var connection = new OracleConnection(ConnectionStrings.ManagedConnectionString());

            var cmd = new OracleCommand("SERNOS_PACK_V2.GET_PRODUCT_GROUP", connection)
                          {
                              CommandType = CommandType.StoredProcedure
                          };

            var result = new OracleParameter(null, OracleDbType.Varchar2)
                             {
                                 Direction = ParameterDirection.ReturnValue,
                                 Size = 50
                             };
            cmd.Parameters.Add(result);

            var partNumberParameter = new OracleParameter("p_part_number", OracleDbType.Varchar2)
                                        {
                                            Direction = ParameterDirection.Input,
                                            Size = 50,
                                            Value = partNumber
                                        };
            cmd.Parameters.Add(partNumberParameter);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
            
            return result.Value.ToString();
        }

        public bool CheckSernosTrans(string transCode, string articleNumber, int sernosNumber)
        {
            var connection = new OracleConnection(ConnectionStrings.ManagedConnectionString());

            var cmd = new OracleCommand("SERNOS_PACK_V2.CHECK_SERNOS_TRANS_SQL", connection)
                          {
                              CommandType = CommandType.StoredProcedure
                          };

            var result = new OracleParameter(null, OracleDbType.Int32)
                             {
                                 Direction = ParameterDirection.ReturnValue
                             };
            cmd.Parameters.Add(result);

            var sernosTransParameter = new OracleParameter("p_sernos_trans", OracleDbType.Varchar2)
                                          {
                                              Direction = ParameterDirection.Input,
                                              Size = 50,
                                              Value = transCode
                                          };
            cmd.Parameters.Add(sernosTransParameter);

            var partNumberParameter = new OracleParameter("p_part_number", OracleDbType.Varchar2)
                                          {
                                              Direction = ParameterDirection.Input,
                                              Size = 50,
                                              Value = articleNumber
                                          };
            cmd.Parameters.Add(partNumberParameter);

            var serialNumberParameter = new OracleParameter("p_serial_number", OracleDbType.Varchar2)
                                          {
                                              Direction = ParameterDirection.Input,
                                              Size = 50,
                                              Value = sernosNumber
                                          };
            cmd.Parameters.Add(serialNumberParameter);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();

            var success = int.Parse(result.Value.ToString());

            return success == 1;
        }

        public string GetSernosMessage()
        {
            var connection = new OracleConnection(ConnectionStrings.ManagedConnectionString());

            var cmd = new OracleCommand("SERNOS_PACK_V2.SERNOS_MESS", connection)
                          {
                              CommandType = CommandType.StoredProcedure
                          };

            var result = new OracleParameter(null, OracleDbType.Varchar2)
                             {
                                 Direction = ParameterDirection.ReturnValue,
                                 Size = 2000
                             };
            cmd.Parameters.Add(result);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();

            return result.Value.ToString();
        }
    }
}
