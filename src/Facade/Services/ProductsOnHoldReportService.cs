namespace Linn.Products.Facade.Services
{
    using Linn.Common.Facade;
    using Linn.Common.Reporting.Models;
    using Linn.Products.Domain.Linnapps.Repositories;

    public class ProductsOnHoldReportService : IProductsOnHoldReportService
    {
        private readonly IProductsOnHoldService service;

        public ProductsOnHoldReportService(IProductsOnHoldService service)
        {
            this.service = service;
        }

        public IResult<ResultsModel> GetProductsOnHoldReport()
        {
            var results = this.service.GetProductsOnHold();
            return new SuccessResult<ResultsModel>(results);
        }
    }
}
