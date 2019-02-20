namespace Linn.Products.Resources
{
    using Linn.Common.Resources;

    public class ProductRangeResource : HypermediaResource
    {
        public int Id { get; set; }

        public string RangeName { get; set; }

        public string RangeDescription { get; set; }

        public string DateInvalid { get; set; }
    }
}
