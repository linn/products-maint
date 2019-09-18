namespace Linn.Products.Domain.Linnapps.Models
{
    public class ProductionTriggerLevel
    {
        public string PartNumber { get; set; }

        public string CitCode { get; set; }

        public int? VariableTriggerLevel { get; set; }

        public int? OverrideTriggerLevel { get; set; }

        public int? KanbanSize { get; set; }
    }
}
