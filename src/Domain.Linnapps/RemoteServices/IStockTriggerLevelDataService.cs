namespace Linn.Products.Domain.Linnapps.RemoteServices
{
    using System.Data;

    public interface IStockTriggerLevelDataService
    {
        DataTable GetStockTriggerLevelsForPartAtLocation(int locationId, string partNumber);

        DataTable GetPartDataAtLocation(int locationId);

        int GetQtyAvailableAtEk2Location(string partNumber);
    }
}