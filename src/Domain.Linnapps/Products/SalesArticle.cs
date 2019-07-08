namespace Linn.Products.Domain.Linnapps.Products
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class SalesArticle
    {
        public string ArticleNumber { get; set; }

        public string ArticleType { get; set; }

        public string TypeOfSale { get; set; }

        public string InvoiceDescription { get; set; }

        public string EanCode { get; set; }

        public string PackingDescription { get; set; }

        public string SaDiscountFamily { get; set; }

        public DateTime? PhaseInDate { get; set; }

        public DateTime? PhaseOutDate { get; set; }

        public string CartonType { get; set; }

        public decimal? PercentageOfRootProductSales { get; set; }

        public DateTime? ForecastFromDate { get; set; }

        public DateTime? ForecastToDate { get; set; }

        public string ForecastType { get; set; }

        public string RootProduct { get; set; }

        public string TypeOfSerialNumber { get; set; }
        
        public int? LastHoldStoryId { get; set; }

        [ForeignKey("SA_CORE_TYPE")]
        public SaCoreType SaCoreType { get; set; }

        public ICollection<SaHoldStory> HoldStories { get; set; }

        public int TariffId { get; set; }

        public void Update(
            string forecastType,
            DateTime? forecastFromDate,
            DateTime? forecastToDate,
            decimal? percentageOfRootProductSales,
            SaCoreType coreType)
        {
            this.ForecastType = forecastType;
            this.ForecastFromDate = forecastFromDate;
            this.ForecastToDate = forecastToDate;
            this.PercentageOfRootProductSales = percentageOfRootProductSales;
            this.SaCoreType = coreType;
        }
    }
}
