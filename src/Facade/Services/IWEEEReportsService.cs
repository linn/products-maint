namespace Linn.Products.Facade.Services
{
    using Linn.Common.Facade;
    using Linn.Common.Reporting.Models;
    using Linn.Products.Resources;

    public interface IWEEEReportsService
    {
        IResult<ResultsModel> GetWEEEReport(WEEEReportRequestResource resource);
    }
}