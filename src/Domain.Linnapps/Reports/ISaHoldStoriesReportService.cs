namespace Linn.Products.Domain.Linnapps.Reports
{
    using System.Collections.Generic;

    using Linn.Common.Reporting.Models;

    public interface ISaHoldStoriesReportService
    {
        ResultsModel GetSaHoldStoriesReportForSalesArticle(string articleNumber);

        IEnumerable<string> GetArticleNumbersWithHoldStories();
    }
}
