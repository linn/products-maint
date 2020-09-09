namespace Linn.Products.Resources.MessageResources
{
    using System.Collections.Generic;
    using Linn.Common.Configuration;
    using Linn.Products.Resources.ProductsResources;

    public class RootProductMessageResource : EntityMessageResource
    {
        public RootProductMessageResource()
        {
            this.links = new List<LinkResource>();
        }

        public string href
        {
            get
            {
                var appRoot = ConfigurationManager.Configuration["APP_ROOT"];
                return $"{appRoot}/root-products/{this.id}";
            }
        }

        public CartonResource carton { get; set; }

        public string description { get; set; }

        public string name { get; set; }

        public SalesProductMessageResource salesProduct { get; set; }

        public ProductRangeMessageResource productRange { get; set; }

        public bool hasSerialNumberOnBoard { get; set; }

        public ProcommCategoryResource procommCategory { get; set; }

        public IList<LinkResource> links { get; set; }
    }
}
