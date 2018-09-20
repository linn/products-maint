namespace Linn.Products.Domain.Reports
{
    using System.Linq;

    using Linn.Common.Reporting.Models;
    using Linn.Products.Domain.RemoteServices;

    public class EanCodeReportService : IEanCodeReportService
    {
        private readonly ISalesArticleService salesArticleService;

        public EanCodeReportService(ISalesArticleService salesArticleService)
        {
            this.salesArticleService = salesArticleService;
        }

        public ResultsModel GetEanCodeReport(bool includePhasedOut = false, bool cartonisedOnly = false)
        {
            var articles = this.salesArticleService.GetByDiscountFamily("HIFI", includePhasedOut);
            if (cartonisedOnly)
            {
                articles = articles.Where(c => !string.IsNullOrEmpty(c.CartonType));
            }

            var results = new ResultsModel(new[] { "Article No", "Description", "EAN Code" })
                              {
                                  ReportTitle = new NameModel("Sales Article EAN Codes")
                              };

            foreach (var salesArticle in articles)
            {
                var row = results.AddRow(salesArticle.ArticleNumber);
                results.SetGridTextValue(row.RowIndex, 0, salesArticle.ArticleNumber);
                results.SetGridTextValue(row.RowIndex, 1, salesArticle.InvoiceDescription);
                results.SetGridTextValue(row.RowIndex, 2, salesArticle.EanCode);
            }

            return results;
        }
    }
}
