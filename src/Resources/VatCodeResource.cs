namespace Linn.Products.Resources
{
    using Linn.Common.Resources;

    public class VatCodeResource : HypermediaResource
    {
        public string Code { get; set; }

        public string Description { get; set; }

        public double Rate { get; set; }

        public string Reason { get; set; }

        public string VatOnly { get; set; }

        public int? VatReturnId { get; set; }
    }
}