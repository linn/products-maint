namespace Linn.Products.Domain.Linnapps.SalesPackages
{
    using System.Collections.Generic;

    public class SalesPackage
    {
        public int Id { get; set; }

        public string SalesPackageId { get; set; }

        public string Description { get; set; }

        public IList<SalesPackageElementJoin> Elements { get; set; } = new List<SalesPackageElementJoin>();
    }
}
