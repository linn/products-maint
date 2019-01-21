namespace Linn.Products.Resources
{
    using Linn.Common.Resources;

    public class TypeOfSaleResource : HypermediaResource
    {
        public string Name { get; set; }

        public string Department { get; set; }

        public string Description { get; set; }

        public string Nominal { get; set; }

        public string RealSale { get; set; }
    }
}