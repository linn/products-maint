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

            var results = new ResultsModel(new[] { "Description", "EAN Code" })
                              {
                                  RowHeader = "Article Number",
                                  ReportTitle = new NameModel("Sales Article EAN Codes")
                              };

            results.SetColumnType(0, GridDisplayType.TextValue);
            results.SetColumnType(1, GridDisplayType.TextValue);

            foreach (var salesArticle in articles.OrderBy(a => a.ArticleNumber))
            {
                var row = results.AddRow(salesArticle.ArticleNumber);
                results.SetGridTextValue(row.RowIndex, 0, salesArticle.InvoiceDescription);
                results.SetGridTextValue(row.RowIndex, 1, salesArticle.EanCode);
            }

            return results;
        }
    }
}
