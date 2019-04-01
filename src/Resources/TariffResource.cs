namespace Linn.Products.Resources
{
    using Common.Resources;
    using FluentValidation;

    public class TariffResource : HypermediaResource
    {
        public int Id { get; set; }

        public string TariffCode { get; set; }

        public string Description { get; set; }

        public string USTariffCode { get; set; }

        public string DateInvalid { get; set; }

        public decimal? Duty { get; set; }
    }
}
