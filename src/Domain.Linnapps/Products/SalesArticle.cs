namespace Linn.Products.Domain.Linnapps.Products
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class SalesArticle
    {
        public string ArticleNumber { get; set; }

        public string TypeOfSale { get; set; }

        public string InvoiceDescription { get; set; }

        public string EanCode { get; set; }

        public string PackingDescription { get; set; }

        public string SaDiscountFamily { get; set; }

        [Display(Name = "Phased In")]
        [DataType(DataType.Date)] public DateTime? PhaseInDate { get; set; }

        [Display(Name = "Phased Out")]
        [DataType(DataType.Date)]
        public DateTime? PhaseOutDate { get; set; }

        public string CartonType { get; set; }
    }
}
