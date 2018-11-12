namespace Linn.Products.Resources
{
    using Linn.Common.Resources;

    public class SaCoreTypeResource : HypermediaResource
    {
        public int CoreType { get; set; }

        public string Description { get; set; }

        public string DateInvalid { get; set; }

        public int? LookAheadDays { get; set; }

        public int? SortOrder { get; set; }

        public int? TriggerLevel { get; set; }
    }
}
