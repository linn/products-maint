namespace Linn.Products.Facade.Services
{
    using System.Collections.Generic;

    using Linn.Common.Facade;
    using Linn.Common.Reporting.Models;

    public interface ISaHoldStoriesReportService
    {
        IResult<ResultsModel> GetHoldStoriesForSalesArticle(string articleNumber);

        IResult<ResultsModel> GetHoldStoriesForRootProduct(string rootProductName);
    }
}
