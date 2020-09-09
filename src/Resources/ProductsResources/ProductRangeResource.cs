namespace Linn.Products.Resources.ProductsResources
{
    public class ProductRangeResource : PhaseOutableEntityResource
    {
        public string href => $"/products/product-ranges/{this.id}";

        public string description { get; set; }

        public string name { get; set; }
    }
}