namespace Linn.Products.Resources.ProductsResources
{
    using Linn.Common.Configuration;

    public class TypeOfSaleResource : PhaseOutableEntityResource
    {
        public string href
        {
            get
            {
                var appRoot = ConfigurationManager.Configuration["APP_ROOT"];
                return $"{appRoot}/types-of-sale/{this.id}";
            }
        }

        public string name { get; set; }

        public string description { get; set; }
    }
}
