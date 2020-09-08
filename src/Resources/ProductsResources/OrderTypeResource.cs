namespace Linn.Products.Resources.ProductsResources
{
    using System.Configuration;

    using Linn.Common.Configuration;

    public class OrderTypeResource : PhaseOutableEntityResource
    {
        public string href
        {
            get
            {
                var appRoot = ConfigurationManager.Configuration["APP_ROOT"];
                return string.Format(appRoot + "/order-types/{0}", this.id);
            }
        }

        public string description { get; set; }

        public int triggerLevel { get; set; }

        public int lookAheadDays { get; set; }
    }
}