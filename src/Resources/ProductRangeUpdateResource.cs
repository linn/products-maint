namespace Linn.Products.Resources
{
    using Linn.Common.Resources;

    public class ProductRangeUpdateResource : HypermediaResource
    {
        public string RangeName { get; set; }

        public string RangeDescription { get; set; }

        public string DateInvalid { get; set; }
    }
}
