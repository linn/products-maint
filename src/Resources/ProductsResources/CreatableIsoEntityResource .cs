namespace Linn.Products.Resources.ProductsResources
{
    public abstract class CreatableIsoEntityResource : HypermediaResource
    {
        public int? id { get; set; }

        public string createdOn { get; set; }
    }
}