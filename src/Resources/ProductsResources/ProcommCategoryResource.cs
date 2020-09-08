namespace Linn.Products.Resources.ProductsResources
{
    using Linn.Common.Configuration;

    public class ProcommCategoryResource : PhaseOutableEntityResource
    {
        public string href
        {
            get
            {
                var appRoot = ConfigurationManager.Configuration["APP_ROOT"];
                return $"{appRoot}/procomm-categories/{this.id}";
            }
        }

        public string description { get; set; }
    }
}
