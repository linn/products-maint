namespace Linn.Products.Domain.Linnapps.Products
{
    using Linn.Products.Domain.Linnapps.Models;

    public interface ISalesArticleCompositeDiscountService
    {
        SalesArticleCompositeDiscount GetCompositeDiscount(string articleNumber);

        SalesArticleCompositeDiscount SetCompositeDiscount(
            string articleNumber,
            string baseArticleNumber,
            string noDiscountArticleNumber);
    }
}