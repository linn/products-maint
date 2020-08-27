namespace Linn.Products.Resources
{
    using Linn.Common.Resources;

    public class SalesArticlesReallocatorResource : HypermediaResource
    {
        public string OldTariffId { get; set; }

        public string NewTariffId { get; set; }

    }
}
