namespace Linn.Products.Proxy
{
    using System;
    using System.Data;
    using System.Globalization;

    using Linn.Products.Domain.Linnapps.RemoteServices;

    public class OrdersByNominalDatabaseService : IOrdersByNominalDatabaseService
    {

        private readonly IDatabaseService databaseService;

        public OrdersByNominalDatabaseService(IDatabaseService databaseService)
        {
            this.databaseService = databaseService;
        }

        public DataTable GetDataTable(DateTime from, DateTime to, string nominal = null)
        {
            
            var queryClause = nominal != null ? $"WHERE n.nomacc_id = {nominal}" : string.Empty; // TODO - options Danielle wants?
            var x = from.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            var sql = $@"SELECT plorl.order_number, 
                        SUBSTR(PLORH.DOCUMENT_TYPE,1,1) DOC_TYPE,
                        PLORH.DATE_OF_ORDER DATE_OF_ORDER,
                        PLORL.ORDER_LINE ORDER_LINE, PLORL.PART_NUMBER PART_NUMBER,
                        plorl.suppliers_designation,   
                        PLORL.NET_TOTAL net_total,
                        decode(plorh.document_type,'CO',plorl.our_qty*-1,plorl.our_qty)  our_qty,
                        s.live_on_oracle,
                        decode(plorh.document_type,'CO',plop.qty*-1,plop.qty)  qty,
                        decode(plorh.document_type,'CO',plop.qty*-1,plop.qty) * plorl.base_our_unit_price plop_value ,
                        plorl.next_our_unit_price,
                        plorl.base_our_unit_price
                        FROM PL_ORDERS PLORH,PL_ORDER_DETAILS PLORL,
                        suppliers s,
                        pl_order_postings plop,nominal_accounts n
                        WHERE 
                        PLORH.DATE_OF_ORDER BETWEEN to_date('{from.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)}', 'dd/mm/yyyy') 
                        AND  to_date('{to.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)}', 'dd/mm/yyyy')
                        and plorh.supp_supplier_id = s.supplier_id
                        and plorl.ORDER_NUMBER = PLORh.ORDER_NUMBER
                        and plorl.order_number = plop.plorl_order_number
                        and plorl.order_line = plorl.order_line 
                        and plop.nomacc_id = n.nomacc_id 
                        {queryClause}
                        order by plorh.order_number,plorl.order_line";
            var table = this.databaseService.ExecuteQuery(sql).Tables[0];
            var orderNumber = table.Rows[0][0];
            var orderLine = table.Rows[0][3];

            //var test = this.GetQtyInv((int), (int)table.Rows[0][1]); // todo add the stuff stephanie/danielle want to this report??
            return this.databaseService.ExecuteQuery(sql).Tables[0];
        }

        public decimal GetQtyOutstanding(decimal baseOurUnitPrice, decimal ourQty, decimal qtyReceived, decimal qty)
        {
            var val = baseOurUnitPrice * (ourQty - qtyReceived) * qty / ourQty;

            return val < 0 ? val : 0;
        }

        public decimal GetQtyInv(int orderNumber, int orderLine)
        {
            var result = this.databaseService.ExecuteQuery(
                $@"select sum(pl_pack.get_payment_value(pl_trans_type,pl_qty) )
                from purchase_ledger where order_number = {orderNumber} and order_line = {orderLine}");

            var table = result.Tables[0];

            return new decimal((int)table.Rows[0][0]);
        }
    }
}