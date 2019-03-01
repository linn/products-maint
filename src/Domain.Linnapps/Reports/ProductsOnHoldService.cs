namespace Linn.Products.Domain.Linnapps.Reports
{
    using System;
    using System.Linq;
    
    using Linn.Common.Persistence;
    using Linn.Common.Reporting.Models;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Domain.Linnapps.Repositories;

    public class ProductsOnHoldService : IProductsOnHoldService
    {
        private readonly IRepository<SaHoldStory, int> saHoldStoryRepository;
        private readonly IRepository<SalesArticle, string> salesArticleRepository;
        private readonly IEmployeeRepository employeeRepository;

        public ProductsOnHoldService(
            IRepository<SaHoldStory, int> saHoldStoryRepository,
            IRepository<SalesArticle, string> salesArticleRepository,
            IEmployeeRepository employeeRepository)
        {
            this.saHoldStoryRepository = saHoldStoryRepository;
            this.salesArticleRepository = salesArticleRepository;
            this.employeeRepository = employeeRepository;
        }

        public ResultsModel GetProductsOnHold()
        {
            var stories = this.saHoldStoryRepository.FindAll();
            var salesArticles = this.salesArticleRepository.FindAll();
            var employees = this.employeeRepository.GetEmployees();
            var productsOnHold = from story in stories
                                 join article in salesArticles on story.ArticleNumber equals article.ArticleNumber
                                 join employee in employees on story.PutOnHoldByEmployeeNumber equals employee.Id
                                 where (story.DateFinished == null)
                                 select new
                                            {
                                                ArticleNumber = article.ArticleNumber,
                                                InvoiceDescription = article.InvoiceDescription,
                                                PutOnHoldBy = employee.FullName,
                                                DateStarted = story.DateStarted,
                                                AnticipatedEndDate = story.AnticipatedEndDate,
                                                ReasonStarted = story.ReasonStarted
                                            };

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

            foreach (var productOnHold in productsOnHold)
            {
                var row = results.AddRow(productOnHold.ArticleNumber);
                results.SetGridTextValue(row.RowIndex, 0, productOnHold.ArticleNumber);
                results.SetGridTextValue(row.RowIndex, 1, productOnHold.InvoiceDescription);
                results.SetGridTextValue(row.RowIndex, 2, productOnHold.PutOnHoldBy.ToString());
                results.SetGridTextValue(row.RowIndex, 3, productOnHold.DateStarted.ToShortDateString());
                results.SetGridTextValue(row.RowIndex, 4, productOnHold.AnticipatedEndDate != null ? ((DateTime) productOnHold.AnticipatedEndDate).ToShortDateString() : null);
                results.SetGridTextValue(row.RowIndex, 5, productOnHold.ReasonStarted);
            }

            return results;
        }
    }
}
