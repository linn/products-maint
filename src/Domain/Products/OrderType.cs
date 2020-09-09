namespace Linn.Products.Domain.Products
{
    public class OrderType : PhaseOutableEntity
    {
        public string Description { get; set; }

        public int TriggerLevel { get; set; }

        public int LookAheadDays { get; set; }
    }
}
