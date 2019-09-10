namespace Linn.Products.Domain.Linnapps.RemoteServices
{
    using System;
    using System.Data;

    public interface IOrdersByNominalDatabaseService
    {
        DataTable GetDataTable(DateTime from, DateTime to, string nominal);

        decimal GetQtyOutstanding(decimal baseOurUnitPrice, decimal ourQty, decimal qtyReceived, decimal qty);

        decimal GetQtyInv(int orderNumber, int orderLine);
    }
}