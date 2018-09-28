namespace Linn.Products.Domain.Reports
{
    using System.Linq;

    using Linn.Common.Reporting.Models;
    using Linn.Products.Domain.Repositories;

    public class ProductReports : IProductReports
    {
        private readonly IProductRangeRepository productRangeRepository;

        public ProductReports(IProductRangeRepository productRangeRepository)
        {
            this.productRangeRepository = productRangeRepository;
        }

        public ResultsModel GetProductRangeReport(bool includePhasedOut = false)
        {
            var productRanges = this.productRangeRepository.GetProductRanges();
            if (!includePhasedOut)
            {
                productRanges = productRanges.Where(p => p.PhasedOutOn == null);
            }

            var results = new ResultsModel(new[] { "Name", "Description", "Phased Out On" })
                              {
                                  RowHeader = "Id",
                                  ReportTitle = new NameModel("Product Ranges")
                              };

            results.SetColumnType(0, GridDisplayType.TextValue);
            results.SetColumnType(1, GridDisplayType.TextValue);
            results.SetColumnType(2, GridDisplayType.TextValue);

            foreach (var productRange in productRanges.OrderBy(a => a.Name))
            {
                var row = results.AddRow(productRange.Id.ToString());
                results.SetGridTextValue(row.RowIndex, 0, productRange.Name);
                results.SetGridTextValue(row.RowIndex, 1, productRange.Description);
                results.SetGridTextValue(row.RowIndex, 2, productRange.PhasedOutOn?.ToShortDateString());
            }

            return results;
        }
    }
}
