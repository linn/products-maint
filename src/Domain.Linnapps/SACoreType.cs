namespace Linn.Products.Domain.Linnapps
{
    using System;

    public class SaCoreType
    {
        public SaCoreType(
            int coreType,
            string description,
            DateTime? dateInvalid = null,
            int? lookAheadDays = null,
            int? sortOrder = null,
            int? triggerLevel = null)
        {
            this.CoreType = coreType;
            this.Description = description;
            this.DateInvalid = dateInvalid;
            this.SortOrder = sortOrder;
            this.TriggerLevel = triggerLevel;
        }

        public int CoreType { get; set; }

        public string Description { get; set; }

        public DateTime? DateInvalid { get; set; }

        public int? LookAheadDays { get; set; }

        public int? SortOrder { get; set; }

        public int? TriggerLevel { get; set; }

        public void Update(
            string description,
            DateTime? dateInvalid = null,
            int? lookAheadDays = null,
            int? sortOrder = null,
            int? triggerLevel = null)
        {
            this.Description = description;
            this.DateInvalid = dateInvalid;
            this.LookAheadDays = lookAheadDays;
            this.SortOrder = sortOrder;
            this.TriggerLevel = triggerLevel;
        }
    }
}
