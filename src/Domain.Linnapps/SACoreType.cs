namespace Linn.Products.Domain.Linnapps
{
    using System;

    public class SACoreType
    {
        public int CoreType { get; set; }

        public string Description { get; set; }

        public DateTime? DateInvalid { get; set; }

        public int? LookAheadDays { get; set; }

        public int? SortOrder { get; set; }

        public int? TriggerLevel { get; set; }
    }
}
