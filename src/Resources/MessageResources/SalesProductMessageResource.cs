namespace Linn.Products.Resources.MessageResources
{
    using Linn.Products.Resources.ProductsResources;
    using System.Collections.Generic;
    using Linn.Common.Configuration;

    public class SalesProductMessageResource : EntityMessageIsoDateResource
    {
        public SalesProductMessageResource()
        {
            this.reportingAttributes = new List<ReportingAttributeResource>();    
        }

        public string name { get; set; }

        public string description { get; set; }

        public string phasedInOn { get; set; }

        public ProductRangeMessageResource productRange { get; set; }

        public string href
        {
            get
            {
                var appRoot = ConfigurationManager.Configuration["APP_ROOT"];
                return $"{appRoot}/sales-products/{this.id}";
            }
        }
    }
}