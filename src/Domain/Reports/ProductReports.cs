namespace Linn.Products.Domain.Reports
{
    using System.Linq;

    using Linn.Common.Reporting.Models;
    using Linn.Products.Domain.Repositories;

    public class ProductReports : IProductReports
    {
        private readonly IProductRangeRepository productRangeRepository;

        private readonly ISalesProductRepository salesProductRepository;

        public ProductReports(
            IProductRangeRepository productRangeRepository,
            ISalesProductRepository salesProductRepository)
        {
            this.productRangeRepository = productRangeRepository;
            this.salesProductRepository = salesProductRepository;
        }

        public ResultsModel GetProductRangeReport(bool includePhasedOut = false)
        {
            var productRanges = this.productRangeRepository.GetProductRanges();
            if (!includePhasedOut)
            {
                productRanges = productRanges.Where(p => p.PhasedOutOn == null);
            }

            var results = new ResultsModel(new[] { "Name", "Description" })
                              {
                                  RowHeader = "Id",
                                  ReportTitle = new NameModel("Product Ranges")
                              };

            results.SetColumnType(0, GridDisplayType.TextValue);
            results.SetColumnType(1, GridDisplayType.TextValue);

            if (includePhasedOut)
            {
                results.AddColumn("Phased Out On");
                results.SetColumnType(2, GridDisplayType.TextValue);
            }

            foreach (var productRange in productRanges.OrderBy(a => a.Name))
            {
                var row = results.AddRow(productRange.Id.ToString());
                results.SetGridTextValue(row.RowIndex, 0, productRange.Name);
                results.SetGridTextValue(row.RowIndex, 1, productRange.Description);
                if (includePhasedOut)
                {
                    results.SetGridTextValue(row.RowIndex, 2, productRange.PhasedOutOn?.ToShortDateString());
                }
            }

            results.ValueDrillDownTemplates.Add(
                new DrillDownModel(
                    "sales-products",
                    $"/products/reports/sales-products-by-product-range?productRangeId={{rowId}}&productRangeName={{textValue}}&includePhasedOut={includePhasedOut.ToString().ToLowerInvariant()}",
                    null,
                    0));

            return results;
        }

        public ResultsModel GetSalesProductByRangeReport(int productRangeId, bool includePhasedOut = false)
        {
            var salesProducts = this.salesProductRepository.GetSalesProducts();
            salesProducts = salesProducts.Where(s => s.ProductRange?.Id == productRangeId);

            if (!includePhasedOut)
            {
                salesProducts = salesProducts.Where(p => p.PhasedOutOn == null);
            }

            var results = new ResultsModel(new[] { "Name", "Description" })
                              {
                                  RowHeader = "Id",
                                  ReportTitle = new NameModel("Sales Products")
                              };

            results.SetColumnType(0, GridDisplayType.TextValue);
            results.SetColumnType(1, GridDisplayType.TextValue);

            if (includePhasedOut)
            {
                results.AddColumn("Phased Out On");
                results.SetColumnType(2, GridDisplayType.TextValue);
            }

            foreach (var salesProduct in salesProducts.OrderBy(a => a.Name))
            {
                var row = results.AddRow(salesProduct.Id.ToString());
                results.SetGridTextValue(row.RowIndex, 0, salesProduct.Name);
                results.SetGridTextValue(row.RowIndex, 1, salesProduct.Description);
                if (includePhasedOut)
                {
                    results.SetGridTextValue(row.RowIndex, 2, salesProduct.PhasedOutOn?.ToShortDateString());
                }
            }

            results.ValueDrillDownTemplates.Add(
                new DrillDownModel(
                    "details",
                    $"/products/sales-products/{{rowId}}",
                    null,
                    0));

            return results;
        }
    }
}
