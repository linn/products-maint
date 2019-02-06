namespace Linn.Products.Facade.Services
{
    using Linn.Common.Facade;
    using Linn.Common.Reporting.Models;

    public interface IStockTriggerLevelsService
    {
        IResult<ResultsModel> GetStockTriggerLevelsForPartAtLocation(int locationId, string partNumber);

        IResult<ResultsModel> GetPartDataAtLocation(int locationId);
    }
}

