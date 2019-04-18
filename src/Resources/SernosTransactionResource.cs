namespace Linn.Products.Resources
{
    using Linn.Common.Resources;

    public class SernosTransactionResource : HypermediaResource
    {
        public string TransCode { get; set; }

        public string TransDescription { get; set; }

        public string Comments { get; set; }
    }
}
