namespace Linn.Products.Domain.Linnapps.RemoteServices
{
    using System.Data;

    public interface IStockTriggerLevelReportService
    {
        DataTable GetStockTriggerLevelsForPartAtLocation(int locationId, string partNumber);

        DataTable GetPartDataAtLocation(int locationId);
    }
}