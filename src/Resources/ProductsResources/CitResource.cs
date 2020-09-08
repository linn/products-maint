namespace Linn.Products.Resources.ProductsResources
{
    public class CitResource : PhaseOutableEntityResource
    {
        public string href => $"/cits/{this.id}";

        public string code { get; set; }

        public string description { get; set; }
    }
}
