namespace Linn.Products.Domain.Linnapps.SalesPackages
{
    using System.Collections.Generic;

    public class SalesPackageElement
    {
        public string SalesPackageId { get; set; }

        public string ElementType { get; set; }

        public int Sequence { get; set; }

        public int Quantity { get; set; }

        public IList<SalesPackageElementJoin> Packages { get; set; } = new List<SalesPackageElementJoin>();
    }
}
