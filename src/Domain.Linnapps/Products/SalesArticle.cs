namespace Linn.Products.Domain.Linnapps.Products
{
    using System;

    public class SalesArticle
    {
        public string ArticleNumber { get; set; }

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

        public void UpdateForecastInformation(
            string forecastType,
            DateTime? forecastFromDate,
            DateTime? forecastToDate,
            decimal? percentageOfRootProductSales)
        {
            this.ForecastType = forecastType;
            this.ForecastFromDate = forecastFromDate;
            this.ForecastToDate = forecastToDate;
            this.PercentageOfRootProductSales = percentageOfRootProductSales;
        }
    }
}
