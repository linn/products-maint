namespace Linn.Products.Domain.Products
{
    using System;

    public class Tariff
    {
        public int? Id { get; set; }

        public Uri CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public Uri PhasedOutBy { get; set; }

        public DateTime? PhasedOutOn { get; set; }

        public string Description { get; set; }

        public string UkTariffCode { get; set; }

        public string UsTariffCode { get; set; }
    }
}
