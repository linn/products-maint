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

        public ProductsOnHoldService(IRepository<SaHoldStory, int> saHoldStoryRepository)
        {
            this.saHoldStoryRepository = saHoldStoryRepository; 
        }

        public ResultsModel GetProductsOnHold()
        {
            var productsOnHold = this.saHoldStoryRepository.FindAll().Where(s => s.DateFinished == null);  
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
                results.SetGridTextValue(row.RowIndex, 0, productOnHold.SalesArticle.ArticleNumber);
                results.SetGridTextValue(row.RowIndex, 1, productOnHold.SalesArticle.InvoiceDescription);
                results.SetGridTextValue(row.RowIndex, 2, productOnHold.PutOnHoldByEmployee.FullName);
                results.SetGridTextValue(row.RowIndex, 3, productOnHold.DateStarted.ToShortDateString());
                results.SetGridTextValue(row.RowIndex, 4, productOnHold.AnticipatedEndDate != null ? ((DateTime) productOnHold.AnticipatedEndDate).ToShortDateString() : null);
                results.SetGridTextValue(row.RowIndex, 5, productOnHold.ReasonStarted);
            }

            return results;
        }
    }
}
