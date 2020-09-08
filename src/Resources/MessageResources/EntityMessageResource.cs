namespace Linn.Products.Resources.MessageResources
{
    using Linn.Common.Resources;
    using System;
    using System.Collections.Generic;

    using Linn.Products.Resources.ProductsResources;

    public abstract class EntityMessageResource
    {
        protected EntityMessageResource()
        {
            this.reportingAttributes = new List<ReportingAttributeResource>();
        }

        public int id { get; set; }

        public LinkResource phasedOutBy { get; set; }

        public DateTime? phasedOutOn { get; set; }

        public LinkResource createdBy { get; set; }

        public DateTime createdOn { get; set; }

        public IList<ReportingAttributeResource> reportingAttributes { get; set; }
    }
}
