namespace Linn.Products.Domain.Linnapps
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Linn.Products.Domain.Linnapps.Exceptions;

    [Table("SA_CORE_TYPES")]
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
        [Key]
        [Column("CORE_TYPE")]
        public int CoreType { get; set; }

        [Column("DESCRIPTION")]
        public string Description { get; set; }

        [Column("DATE_INVALID")]
        public DateTime? DateInvalid { get; set; }

        [Column("LOOKAHEAD_DAYS")]
        public int? LookAheadDays { get; set; }

        [Column("SORT_ORDER")]
        public int? SortOrder { get; set; }

        [Column("TRIGGER_LEVEL")]
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
