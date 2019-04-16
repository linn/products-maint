namespace Linn.Products.Proxy
{
    using Linn.Products.Domain.Linnapps.Models;
    using Linn.Products.Domain.Linnapps.Products;

    public class SalesArticleCompositeDiscountProxyService : ISalesArticleCompositeDiscountService
    {
        public SalesArticleCompositeDiscount GetCompositeDiscount(string articleNumber)
        {
            throw new System.NotImplementedException();
        }

        public SalesArticleCompositeDiscount SetCompositeDiscount(
            string articleNumber,
            string baseArticleNumber,
            string noDiscountArticleNumber)
        {
            throw new System.NotImplementedException();
        }
    }
}