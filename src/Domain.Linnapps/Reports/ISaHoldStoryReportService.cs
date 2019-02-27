namespace Linn.Products.Domain.Linnapps.Reports
{
    using System.Collections.Generic;

    using Linn.Common.Reporting.Models;

    public interface ISaHoldStoryReportService
    {
        ResultsModel GetSaHoldStoriesReportForSalesArticle(string articleNumber);
    }
}
