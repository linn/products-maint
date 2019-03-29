namespace Linn.Products.Domain.Linnapps.Products
{
    using System;

    public class Tariff
    {
        public int Id { get; set; }

        public string TariffCode { get; set; }

        public string Description { get; set; }

        public string USTariffCode { get; set; }

        public DateTime? DateInvalid { get; set; }

        public decimal? Duty { get; set; }

        public int? EnteredBy { get; set; }

        public int? ChangedBy { get; set; }
    }
}
