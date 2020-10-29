namespace Linn.Products.Resources
{
    using Linn.Common.Resources;

    public class TariffReallocatorResource : HypermediaResource
    {
        public int OldTariffId { get; set; }

        public int NewTariffId { get; set; }

        public int Count { get; set; }
    }
}
