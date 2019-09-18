namespace Linn.Products.Domain.Linnapps.Reports
{
    using Linn.Common.Reporting.Models;

    public interface ISalesArticleReports
    {
        ResultsModel SalesArticleCoreTypeReport();

        ResultsModel SalesArticleTriggerLevelsReport();
    }
}
