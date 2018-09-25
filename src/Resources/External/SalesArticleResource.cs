namespace Linn.Products.Resources.External
{
    using System;

    public class SalesArticleResource
    {
        public string ArticleNumber { get; set; }

        public string CountryCode { get; set; }

        public string TypeOfSale { get; set; }

        public string InvoiceDescription { get; set; }

        public string DiscountFamily { get; set; }

        public string ArticleType { get; set; }

        public string RootProduct { get; set; }

        public int MinimumOrderQty { get; set; }

        public int OrderMulitple { get; set; }

        public DateTime? PhaseInDate { get; set; }

        public DateTime? PhaseOutDate { get; set; }

        public string ShortDescription { get; set; }

        public string Comments { get; set; }

        public string VatCode { get; set; }

        public string EanCode { get; set; }
    }
}
