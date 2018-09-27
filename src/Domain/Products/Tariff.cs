using System;
using System.Collections.Generic;
using System.Text;

namespace Linn.Products.Domain.Products
{
    public class Tariff
    {
        public int Id { get; set; }

        public string TariffCode { get; set; }

        public string Description { get; set; }

        public string USTariffCode { get; set; }

        public DateTime? DateInvalid { get; set; }

        public decimal Duty { get; set; }
    }
}
