namespace Linn.Products.Domain.Linnapps.Reports
{
    using System;
    using System.Linq;
    
    using Linn.Common.Persistence;
    using Linn.Common.Reporting.Models;
    using Linn.Products.Domain.Linnapps.Products;

    public class ProductsOnHoldService : IProductsOnHoldService
    {
        private readonly IRepository<SaHoldStory, int> saHoldStoryRepository;
        private readonly IRepository<SalesArticle, string> salesArticleRepository;

        public ProductsOnHoldService(IRepository<SaHoldStory, int> saHoldStoryRepository, IRepository<SalesArticle, string> salesArticleRepository)
        {
            this.saHoldStoryRepository = saHoldStoryRepository;
            this.salesArticleRepository = salesArticleRepository;
        }

        public ResultsModel GetProductsOnHold()
        {
            var salesArticlesOnHold = this.salesArticleRepository.FindAll().Where(s => s.LastHoldStoryId != null);
            var results = new ResultsModel(new[] { "Article Number", "Invoice Description", "Put On Hold By", "Date Started", "Anticipated End Date", "Reason Started"})
                              {
                                  RowHeader = "Name",
                                  ReportTitle = new NameModel("Products On Hold")
                              };

            results.SetColumnType(0, GridDisplayType.TextValue);
            results.SetColumnType(1, GridDisplayType.TextValue);
            results.SetColumnType(2, GridDisplayType.TextValue);
            results.SetColumnType(3, GridDisplayType.TextValue);
            results.SetColumnType(4, GridDisplayType.TextValue);
            results.SetColumnType(5, GridDisplayType.TextValue);

            foreach (var salesArticleOnHold in salesArticlesOnHold)
            {
                var holdStory = this.saHoldStoryRepository.FindById((int)salesArticleOnHold.LastHoldStoryId);
                var row = results.AddRow(salesArticleOnHold.ArticleNumber.Replace("/", "%2F"), holdStory.ArticleNumber);
                results.SetGridTextValue(row.RowIndex, 0, salesArticleOnHold.ArticleNumber);
                results.SetGridTextValue(row.RowIndex, 1, salesArticleOnHold.InvoiceDescription);
                results.SetGridTextValue(row.RowIndex, 2, holdStory.PutOnHoldByEmployee.FullName);
                results.SetGridTextValue(row.RowIndex, 3, holdStory.DateStarted.ToShortDateString());
                results.SetGridTextValue(row.RowIndex, 4, holdStory.AnticipatedEndDate?.ToShortDateString());
                results.SetGridTextValue(row.RowIndex, 5, holdStory.ReasonStarted);
            }

            results.RowDrillDownTemplates.Add(new DrillDownModel("stories", "/products/maint/sales-articles/{rowId}"));

            return results;
        }
    }
}
