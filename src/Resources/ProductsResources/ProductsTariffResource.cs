namespace Linn.Products.Resources.ProductsResources
{
    using Linn.Common.Configuration;

    public class ProductsTariffResource : EntityResource
    {
        public string href
        {
            get
            {
                var appRoot = ConfigurationManager.Configuration["APP_ROOT"];
                return $"{appRoot}/tariffs/{this.id}";
            }
        }

        public string description { get; set; }

        public string ukTariffCode { get; set; }

        public string usTariffCode { get; set; }
    }
}
