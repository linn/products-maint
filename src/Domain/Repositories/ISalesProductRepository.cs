namespace Linn.Products.Domain.Repositories
{
    using System.Collections.Generic;

    public interface ISalesProductRepository
    {
        IEnumerable<SalesProduct> GetSalesProducts();
    }
}
