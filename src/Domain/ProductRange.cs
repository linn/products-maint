namespace Linn.Products.Domain
{
    using System;

    public class ProductRange : Entity
    {
        public ProductRange(string name)
        {
            this.Name = name;
        }

        private ProductRange()
        {
            // ef
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public string PhasedOutBy { get; set; }

        public DateTime? PhasedOutOn { get; set; }
    }
}