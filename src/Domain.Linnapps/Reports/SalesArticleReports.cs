namespace Linn.Products.Domain.Linnapps.Reports
{
    using System.Linq;

    using Linn.Common.Persistence;
    using Linn.Common.Reporting.Models;
    using Linn.Products.Domain.Linnapps.Products;

    public class SalesArticleReports : ISalesArticleReports
    {
        private readonly IRepository<SalesArticle, string> salesArticleRepository;

        public SalesArticleReports(IRepository<SalesArticle, string> salesArticleRepository)
        {
            this.salesArticleRepository = salesArticleRepository;
        }

        public ResultsModel SalesArticleCoreTypeReport()
        {
            var articles = this.salesArticleRepository.FilterBy(a => a.PhaseOutDate == null && a.SaCoreType != null);
            var results = new ResultsModel(new[] { "Description", "CoreType" })
                              {
                                  RowHeader = "Article Number",
                                  ReportTitle = new NameModel("Sales Article Core Types")
                              };

            results.SetColumnType(0, GridDisplayType.TextValue);
            results.SetColumnType(1, GridDisplayType.TextValue);

            foreach (var salesArticle in articles.OrderBy(a => a.ArticleNumber))
            {
                var row = results.AddRow(salesArticle.ArticleNumber);
                results.SetGridTextValue(row.RowIndex, 0, salesArticle.InvoiceDescription);
                results.SetGridTextValue(row.RowIndex, 1, salesArticle.SaCoreType?.Description);
            }

            return results;
        }
    }
}
