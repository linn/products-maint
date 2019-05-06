namespace Linn.Products.Domain.Linnapps
{
    using System.Collections.Generic;

    public class RootProduct
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<SaHoldStory> HoldStories { get; set; }

    }
}
