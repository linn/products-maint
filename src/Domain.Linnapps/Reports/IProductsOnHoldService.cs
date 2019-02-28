namespace Linn.Products.Domain.Linnapps.Repositories
{
    using Linn.Common.Reporting.Models;

    public interface IProductsOnHoldService
    {
        ResultsModel GetProductsOnHold();
    }
}
