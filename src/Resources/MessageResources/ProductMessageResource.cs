namespace Linn.Products.Resources.MessageResources
{
    using Linn.Common.Resources;
    using System;
    using System.Collections.Generic;

    using Linn.Products.Resources.ProductsResources;

    public abstract class ProductMessageResource : EntityMessageResource
    {
        public string productType { get; set; }

        public TypeOfSaleResource typeOfSale { get; set; }

        public DateTime? phasedInOn { get; set; }

        public string description { get; set; }

        public string shortDescription { get; set; }

        public int minimumOrderQuantity { get; set; }

        public int orderMultiple { get; set; }

        public string name { get; set; }

        public VatCodeResource vatCode { get; set; }

        public string notes { get; set; }

        public string orderInformation { get; set; }

        public AccountingCompanyResource accountingCompany { get; set; }

        public IList<LinkResource> links { get; set; }

        public IList<AttributeValueResource> attributes { get; set; }
    }
}
