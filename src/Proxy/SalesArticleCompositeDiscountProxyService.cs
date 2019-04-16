namespace Linn.Products.Proxy
{
    using System.Data;

    using Linn.Products.Domain.Linnapps.Models;
    using Linn.Products.Domain.Linnapps.Products;

    using Oracle.ManagedDataAccess.Client;

    public class SalesArticleCompositeDiscountProxyService : ISalesArticleCompositeDiscountService
    {
        public SalesArticleCompositeDiscount GetCompositeDiscount(string articleNumber)
        {
            var connection = new OracleConnection(ConnectionStrings.ManagedConnectionString());

            var cmd = new OracleCommand("products_maint_pack.get_composite_discount", connection)
                          {
                              CommandType = CommandType.StoredProcedure
                          };

            var articleParameter = new OracleParameter("p_article_number", OracleDbType.Varchar2)
                                        {
                                            Direction = ParameterDirection.Input,
                                            Size = 50,
                                            Value = articleNumber
                                        };
            cmd.Parameters.Add(articleParameter);

            var baseArticleParameter = new OracleParameter("p_price_from_article", OracleDbType.Varchar2)
                                        {
                                            Direction = ParameterDirection.Output,
                                            Size = 50
                                        };
            cmd.Parameters.Add(baseArticleParameter);

            var noDiscountArticleParameter = new OracleParameter("p_no_disc_price_from_article", OracleDbType.Varchar2)
                                           {
                                               Direction = ParameterDirection.Output,
                                               Size = 50
                                           };
            cmd.Parameters.Add(noDiscountArticleParameter);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();

            return new SalesArticleCompositeDiscount
                       {
                           SalesArticle = articleNumber,
                           BaseSalesArticle = baseArticleParameter.Value?.ToString(),
                           NoDiscountSalesArticle = noDiscountArticleParameter.Value?.ToString()
                       };
        }

        public SalesArticleCompositeDiscount SetCompositeDiscount(
            string articleNumber,
            string baseArticleNumber,
            string noDiscountArticleNumber)
        {
            var connection = new OracleConnection(ConnectionStrings.ManagedConnectionString());

            var cmd = new OracleCommand("products_maint_pack.set_composite_discount", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            var articleParameter = new OracleParameter("p_article_number", OracleDbType.Varchar2)
            {
                Direction = ParameterDirection.Input,
                Size = 50,
                Value = articleNumber
            };
            cmd.Parameters.Add(articleParameter);

            var baseArticleParameter = new OracleParameter("p_price_from_article", OracleDbType.Varchar2)
            {
                Direction = ParameterDirection.Input,
                Size = 50,
                Value = baseArticleNumber
            };
            cmd.Parameters.Add(baseArticleParameter);

            var noDiscountArticleParameter = new OracleParameter("p_no_disc_price_from_article", OracleDbType.Varchar2)
            {
                Direction = ParameterDirection.Input,
                Size = 50,
                Value = noDiscountArticleNumber
            };
            cmd.Parameters.Add(noDiscountArticleParameter);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();

            return new SalesArticleCompositeDiscount
            {
                SalesArticle = articleNumber,
                BaseSalesArticle = baseArticleNumber,
                NoDiscountSalesArticle = noDiscountArticleNumber
            };
        }
    }
}