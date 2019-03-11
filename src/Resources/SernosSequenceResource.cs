namespace Linn.Products.Resources
{
    using Linn.Common.Resources;

    public class SernosSequenceResource : HypermediaResource
    {
        public string DateClosed { get; set; }

        public string Description { get; set; }

        public int NextSerialNumber { get; set; }

        public string SequenceName { get; set; }
    }
}