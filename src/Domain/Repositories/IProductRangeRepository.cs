namespace Linn.Products.Domain.Repositories
{
    using System.Collections.Generic;

    public interface IProductRangeRepository
    {
        IEnumerable<ProductRange> GetProductRanges();
    }
}
