namespace Linn.Products.Resources.External
{
    using System;

    public class ProductRangeResource
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime? PhasedOutOn { get; set; }
    }
}