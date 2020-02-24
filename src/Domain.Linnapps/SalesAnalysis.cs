namespace Linn.Products.Domain.Linnapps
{
    using System;

    public class SalesAnalysis
    {
        public int SanlId { get; set; }

        public string ArticleNumber { get; set; }

        public string AccountingCompany { get; set; }

        public string Countrycode { get; set; }

        public string DocumentType { get; set; }

        public DateTime SanlDate { get; set; }

        public int Quantity { get; set; }
    }
}
