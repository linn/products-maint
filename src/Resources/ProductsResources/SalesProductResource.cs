namespace Linn.Products.Resources.ProductsResources
{
    using System.Configuration;

    using Linn.Common.Configuration;

    public class SalesProductResource : UpdateSalesProductResource
    {
        public string href
        {
            get
            {
                var appRoot = ConfigurationManager.Configuration["APP_ROOT"];
                return $"{appRoot}/sales-products/{this.id}";
            }
        }

        public ProductRangeResource productRange { get; set; }
    }
}