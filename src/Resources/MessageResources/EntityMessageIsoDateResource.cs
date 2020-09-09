namespace Linn.Products.Resources.MessageResources
{
    using System.Collections.Generic;
    using Linn.Products.Resources.ProductsResources;

    public abstract class EntityMessageIsoDateResource : HypermediaResource
    {
        public int id { get; set; }

        public string phasedOutOn { get; set; }

        public string createdOn { get; set; }

        public IList<ReportingAttributeResource> reportingAttributes { get; set; }
    }
}
