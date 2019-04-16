namespace Linn.Products.Facade.Services
{
    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps.Models;
    using Linn.Products.Resources;

    public interface ISalesArticleCompositeDiscountFacadeService
    {
        IResult<SalesArticleCompositeDiscount> GetCompositeDiscount(string articleNumber);

        IResult<SalesArticleCompositeDiscount> SetCompositeDiscount(
            string articleNumber,
            SalesArticleCompositeDiscountResource resource);
    }
}
