namespace Linn.Products.Resources.External
{
    public class SalesProductResource
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string PhasedInOn { get; set; }

        public bool DisplayOnTradeSite { get; set; }

        public string CreatedOn { get; set; }

        public string PhasedOutOn { get; set; }

        public ProductRangeResource ProductRange { get; set; }
    }
}
