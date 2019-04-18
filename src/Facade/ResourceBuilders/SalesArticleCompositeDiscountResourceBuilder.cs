namespace Linn.Products.Facade.ResourceBuilders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Linn.Common.Facade;
    using Linn.Common.Resources;
    using Linn.Products.Domain.Linnapps.Models;
    using Linn.Products.Resources;

    public class SalesArticleCompositeDiscountResourceBuilder : IResourceBuilder<SalesArticleCompositeDiscount>
    {
        public SalesArticleCompositeDiscountResource Build(SalesArticleCompositeDiscount salesArticleCompositeDiscount)
        {
            return new SalesArticleCompositeDiscountResource
                       {
                           ArticleNumber = salesArticleCompositeDiscount.SalesArticle,
                           NoDiscountArticleNumber = salesArticleCompositeDiscount.NoDiscountSalesArticle,
                           BaseArticleNumber = salesArticleCompositeDiscount.BaseSalesArticle,
                           Links = this.BuildLinks(salesArticleCompositeDiscount).ToArray()
                       };
        }

        object IResourceBuilder<SalesArticleCompositeDiscount>.Build(SalesArticleCompositeDiscount salesArticleCompositeDiscount) => this.Build(salesArticleCompositeDiscount);

        public string GetLocation(SalesArticleCompositeDiscount salesArticleCompositeDiscount)
        {
            return $"/products/maint/sales-articles/composite-discounts/{Uri.EscapeDataString(salesArticleCompositeDiscount.SalesArticle)}";
        }

        private IEnumerable<LinkResource> BuildLinks(SalesArticleCompositeDiscount salesArticleCompositeDiscount)
        {
            yield return new LinkResource
                             {
                                 Rel = "self",
                                 Href = this.GetLocation(salesArticleCompositeDiscount)
                             };
        }
    }
}