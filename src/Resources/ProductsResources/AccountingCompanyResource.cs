namespace Linn.Products.Resources.ProductsResources
{
    public class AccountingCompanyResource : PhaseOutableEntityResource
    {
        public string href => $"/accounting-companies/{this.id}";

        public string description { get; set; }

        public string name { get; set; }
    }
}