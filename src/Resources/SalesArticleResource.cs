namespace Linn.Products.Resources
{
    using Linn.Common.Resources;

    public class SalesArticleResource : HypermediaResource
    {
        public string Id { get; set; }

        public string ArticleNumber { get; set; }

        public string TypeOfSale { get; set; }

        public string Description { get; set; }

        public string EanCode { get; set; }

        public string PackingDescription { get; set; }

        public string SaDiscountFamily { get; set; }

        public string PhaseInDate { get; set; }

        public string PhaseOutDate { get; set; }

        public string CartonType { get; set; }

        public decimal? PercentageOfRootProductSales { get; set; }

        public string ForecastFromDate { get; set; }

        public string ForecastToDate { get; set; }

        public string ForecastType { get; set; }

        public string ArticleType { get; set; }

        public bool OnHold { get; set; }
    }
}
