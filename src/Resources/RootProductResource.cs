namespace Linn.Products.Resources
{
    using Linn.Common.Resources;

    public class RootProductResource : HypermediaResource
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public bool onHold { get; set; }
    }
}
