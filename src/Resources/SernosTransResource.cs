namespace Linn.Products.Resources
{
    using Linn.Common.Resources;

    public class SernosTransResource : HypermediaResource
    {
        public string TransCode { get; set; }

        public string TransDescription { get; set; }

        public string Comments { get; set; }
    }
}
