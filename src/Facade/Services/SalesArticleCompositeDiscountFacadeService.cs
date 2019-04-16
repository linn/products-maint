namespace Linn.Products.Facade.Services
{
    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps.Models;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Resources;

    public class SalesArticleCompositeDiscountFacadeService : ISalesArticleCompositeDiscountFacadeService
    {
        private readonly ISalesArticleCompositeDiscountService salesArticleCompositeDiscountService;

        public SalesArticleCompositeDiscountFacadeService(ISalesArticleCompositeDiscountService salesArticleCompositeDiscountService)
        {
            this.salesArticleCompositeDiscountService = salesArticleCompositeDiscountService;
        }

        public IResult<SalesArticleCompositeDiscount> GetCompositeDiscount(string articleNumber)
        {
            var compositeDiscount = this.salesArticleCompositeDiscountService.GetCompositeDiscount(articleNumber);

            return new SuccessResult<SalesArticleCompositeDiscount>(compositeDiscount);
        }

        public IResult<SalesArticleCompositeDiscount> SetCompositeDiscount(
            string articleNumber,
            SalesArticleCompositeDiscountResource resource)
        {
            var result = this.salesArticleCompositeDiscountService.SetCompositeDiscount(
                articleNumber,
                resource.BaseArticleNumber,
                resource.NoDiscountArticleNumber);
            return new SuccessResult<SalesArticleCompositeDiscount>(result);
        }
    }
}
