namespace Linn.Products.Domain.Linnapps.RemoteServices
{
    using System.Collections.Generic;

    using Linn.Products.Domain.Linnapps.Products;

    public interface ISalesArticleService
    {
        IEnumerable<SalesArticle> Search(string searchTerm);

        IEnumerable<SalesArticle> GetByDiscountFamily(string discountFamily, bool includePhasedOut);
    }
}
