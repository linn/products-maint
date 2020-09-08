namespace Linn.Products.Resources.ProductsResources
{
    using Linn.Common.Configuration;

    public class SerialNumberSourceResource : PhaseOutableEntityResource
    {
        public string href
        {
            get
            {
                var appRoot = ConfigurationManager.Configuration["APP_ROOT"];
                return $"{appRoot}/serial-number-sources/{this.id}";
            }
        }

        public string name { get; set; }

        public string description { get; set; }
    }
}
