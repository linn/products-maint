namespace Linn.Products.Resources.External
{
    public class SalesPartResource
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public double? NettWeight { get; set; }

        public bool WeeeProduct { get; set; }

        public bool DimensionOver50Cm { get; set; }

        public string WeeeCategory { get; set; }

        public int? MainsCablesPerProduct { get; set; }

        public double? PackagingNettWeight { get; set; }

        public double? PackagingFoamNettWeight { get; set; }

        public RootProductExternalResource RootProduct { get; set; }
    }
}
