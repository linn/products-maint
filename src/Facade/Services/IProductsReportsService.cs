namespace Linn.Products.Facade.Services
{
    using Linn.Common.Facade;
    using Linn.Common.Reporting.Models;

    public interface IProductsReportsService
    {
        IResult<ResultsModel> GetProductRanges(bool includePhasedOut = false);

        IResult<ResultsModel> GetSalesProductByProductRange(int productRangeId, bool includePhasedOut = false);
    }
}
