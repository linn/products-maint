namespace Linn.Products.Resources
{
    using Linn.Common.Resources;

    public class SalesArticleCompositeDiscountResource : HypermediaResource
    {
        public string ArticleNumber { get; set; }

        public string BaseArticleNumber { get; set; }

        public string NoDiscountArticleNumber { get; set; }
    }
}
