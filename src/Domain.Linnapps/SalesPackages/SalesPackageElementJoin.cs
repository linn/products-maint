namespace Linn.Products.Domain.Linnapps.SalesPackages
{
    public class SalesPackageElementJoin
    {
        public int Id { get; set; }

        public int BridgeId { get; set; }

        public string SalesPackageId { get; set; }

        public string ElementType { get; set; }

        public SalesPackageElement SalesPackageElement { get; set; }

        public SalesPackage SalesPackage { get; set; }
    }
}
