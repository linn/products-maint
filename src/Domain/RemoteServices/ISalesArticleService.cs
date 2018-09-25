namespace Linn.Products.Domain.RemoteServices
{
    using System.Collections.Generic;

    using Linn.Products.Domain.Products;

    public interface ISalesArticleService
    {
        IEnumerable<SalesArticle> Search(string searchTerm);

        IEnumerable<SalesArticle> GetByDiscountFamily(string discountFamily, bool includePhasedOut);
    }
}
