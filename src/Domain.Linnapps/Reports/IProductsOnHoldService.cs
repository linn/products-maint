namespace Linn.Products.Domain.Linnapps.Reports
{
    using Linn.Common.Reporting.Models;

    public interface IProductsOnHoldService
    {
        ResultsModel GetProductsOnHold();
    }
}
