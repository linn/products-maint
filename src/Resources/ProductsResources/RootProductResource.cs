namespace Linn.Products.Resources.ProductsResources
{
    using System.Collections.Generic;
    using Linn.Common.Configuration;
    using Linn.Products.Resources.External;

    public class RootProductResource : PhaseOutableEntityResource
    {
        public RootProductResource()
        {
            this.links = new List<LinkResource>();
        }

        public string href
        {
            get
            {
                var appRoot = ConfigurationManager.Configuration["APP_ROOT"];
                return string.Format(appRoot + "/root-products/{0}", this.id);
            }
        }

        public CartonResource carton { get; set; }

        public string description { get; set; }

        public string name { get; set; }

        public SalesProductResource salesProduct { get; set; }

        public bool hasSerialNumberOnBoard { get; set; }

        public ProcommCategoryResource procommCategory { get; set; }

        public IList<LinkResource> links { get; set; }
    }
}
