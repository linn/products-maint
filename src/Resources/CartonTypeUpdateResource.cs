namespace Linn.Products.Resources
{
    using Linn.Common.Resources;

    public class CartonTypeUpdateResource : HypermediaResource
    {
        public string Description { get; set; }

        public decimal Width { get; set; }

        public decimal Height { get; set; }

        public decimal Depth { get; set; }
    }
}
