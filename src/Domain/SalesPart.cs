namespace Linn.Products.Domain
{
    using Linn.Products.Domain.Linnapps.Products;

    public class SalesPart
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public RootProduct RootProduct { get; set; }
    }
}