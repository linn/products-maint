namespace Linn.Products.Service.ResponseProcessors
{
    using Linn.Common.Facade;
    using Linn.Common.Nancy.Facade;
    using Linn.Products.Domain.Linnapps.Models;

    public class SalesArticleCompositeDiscountResponseProcessor : JsonResponseProcessor<SalesArticleCompositeDiscount>
    {
        public SalesArticleCompositeDiscountResponseProcessor(IResourceBuilder<SalesArticleCompositeDiscount> resourceBuilder)
            : base(resourceBuilder, "sales-article-composite-discount", 1)
        {
        }
    }
}