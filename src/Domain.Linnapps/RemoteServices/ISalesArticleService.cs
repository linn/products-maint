namespace Linn.Products.Domain.Linnapps.RemoteServices
{
    using System.Collections.Generic;

    using Linn.Products.Domain.Linnapps.Products;

    public interface ISalesArticleService
    {
        SalesArticle GetSalesArticle(string id);

        IEnumerable<SalesArticle> Search(string searchTerm);

        IEnumerable<SalesArticle> GetByDiscountFamily(string discountFamily, bool includePhasedOut);
    }
}
