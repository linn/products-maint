namespace Linn.Products.Domain
{
    using System;

    public class SalesProduct : Entity
    {
        public SalesProduct(string name)
        {
            this.Name = name;
        }

        private SalesProduct()
        {
            // ef
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public ProductRange ProductRange { get; set; }

        public DateTime? PhasedInOn { get; set; }

        public DateTime? PhasedOutOn { get; set; }

        public bool DisplayOnTradeSite { get; set; }
    }
}
