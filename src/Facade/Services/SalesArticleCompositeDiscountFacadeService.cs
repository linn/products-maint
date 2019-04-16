namespace Linn.Products.Facade.Services
{
    using System;

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
            throw new NotImplementedException();
        }

        public IResult<SalesArticleCompositeDiscount> SetCompositeDiscount(
            string articleNumber,
            SalesArticleCompositeDiscountResource resource)
        {
            throw new NotImplementedException();
        }
    }
}
