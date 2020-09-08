namespace Linn.Products.Resources.ProductsResources
{
    public class VatCodeResource : EntityResource
    {
        public string href => $"/vat-codes/{this.id}";

        public bool isVatOnly { get; set; }

        public string vatDescription { get; set; }

        public double vatRate { get; set; }

        // this is included only to facilitate syncing with LinnApps - hopefully one
        // day we can remove it... (28/02/2013 - JimL)
        public string linnAppsKey { get; set; }
    }
}