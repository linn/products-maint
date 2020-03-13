namespace Linn.Products.Domain
{
    using Linn.Products.Domain.Linnapps.Products;

    public class SalesPart
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public bool WeeeProduct { get; set; }

        public double? NettWeight { get; set; }

        public bool DimensionOver50Cm { get; set; }

        public string WeeeCategory { get; set; }

        public int? MainsCablesPerProduct { get; set; }

        public double? PackagingNettWeight { get; set; }

        public double? PackagingFoamNettWeight { get; set; }

        public RootProduct RootProduct { get; set; }
    }
}