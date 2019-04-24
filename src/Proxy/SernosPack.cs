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
    }
}
