namespace Linn.Products.Resources
{
    using System.Collections.Generic;

    using Linn.Common.Resources;

    public class SalesPackageResource : HypermediaResource
    {
        public int Id { get; set; }

        public string SalesPackageId { get; set; }

        public string Description { get; set; }

        public IEnumerable<SalesPackageElementResource> Elements { get; set; } = new List<SalesPackageElementResource>();
    }
}
