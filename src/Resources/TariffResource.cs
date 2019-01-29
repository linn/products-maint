namespace Linn.Products.Resources
{
    using System;
    using Common.Resources;

    public class TariffResource : HypermediaResource
    {
        public string TariffCode { get; set; }

        public string Description { get; set; }

        public string USTariffCode { get; set; }

        public string DateInvalid { get; set; }

        public decimal? Duty { get; set; }
    }
}
