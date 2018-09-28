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

        public virtual string CreatedBy { get; set; }

        public virtual DateTime CreatedOn { get; set; }

        public virtual string PhasedOutBy { get; set; }

        public virtual DateTime? PhasedOutOn { get; set; }
    }
}