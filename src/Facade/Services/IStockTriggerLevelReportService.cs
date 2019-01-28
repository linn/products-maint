namespace Linn.Products.Facade.Services
{
    using System.Collections.Generic;

    using Linn.Common.Facade;
    using Linn.Common.Reporting.Models;

    public interface IStockTriggerLevelReportService
    {
        IResult<ResultsModel> GetStockTriggerLevelsForPartAtLocation(int locationId, string partNumber);

        IResult<ResultsModel> GetPartDataAtLocation(int locationId);
    }
}

