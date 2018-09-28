namespace Linn.Products.Facade.Services
{
    using Linn.Common.Facade;
    using Linn.Common.Reporting.Models;
    using Linn.Products.Domain.Reports;

    public class ProductsReportsService : IProductsReportsService
    {
        private readonly IProductReports productReports;

        public ProductsReportsService(IProductReports productReports)
        {
            this.productReports = productReports;
        }

        public IResult<ResultsModel> GetProductRanges(bool includePhasedOut = false)
        {
            var results = this.productReports.GetProductRangeReport(includePhasedOut);
            return new SuccessResult<ResultsModel>(results);
        }
    }
}