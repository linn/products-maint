namespace Linn.Products.Resources.MessageResources
{
    public class ProductRangeMessageResource : EntityMessageResource
    {
        public string href => $"/products/product-ranges/{this.id}";

        public string description { get; set; }

        public string name { get; set; }
    }
}
