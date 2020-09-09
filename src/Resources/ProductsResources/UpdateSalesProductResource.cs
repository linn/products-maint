namespace Linn.Products.Resources.ProductsResources
{
    using System.Collections.Generic;

    public class UpdateSalesProductResource : PhaseOutableIsoEntityResource
    {
        public string name { get; set; }

        public string description { get; set; }

        public string phasedInOn { get; set; }

        public bool displayOnTradeSite { get; set; }

        public IList<ReportingAttributeResource> reportingAttributes { get; set; }
    }
}