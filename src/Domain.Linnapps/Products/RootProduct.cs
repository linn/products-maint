namespace Linn.Products.Domain.Linnapps.Products
{
    using System.Collections.Generic;

    public class RootProduct
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public bool WeeeProduct { get; set; }

        public double? NettWeight { get; set; }

        public ICollection<SaHoldStory> HoldStories { get; set; }
    }
}
