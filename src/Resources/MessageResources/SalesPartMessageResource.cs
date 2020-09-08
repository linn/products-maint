namespace Linn.Products.Resources.MessageResources
{
    using System.Collections.Generic;
    using Linn.Common.Configuration;
    using Linn.Products.Resources.ProductsResources;

    public class SalesPartMessageResource : ProductMessageResource
    {
        public string href
        {
            get
            {
                var appRoot = ConfigurationManager.Configuration["APP_ROOT"];
                return $"{appRoot}/sales-parts/{this.id}";
            }
        }

        public string ean { get; set; }

        public int rootProductVersion { get; set; }

        public double? weightInKg { get; set; }

        public CitResource cit { get; set; }

        public CartonResource carton { get; set; }

        public string barcodePrefix { get; set; }

        public TypeOfSerialNumberResource typeOfSerialNumber { get; set; }

        public SerialNumberSourceResource serialNumberSource { get; set; }

        public string usTariffCode { get; set; }

        public ProductsTariffResource tariff { get; set; }

        public RootProductMessageResource rootProduct { get; set; }

        public bool exDem { get; set; }

        public IList<SalesPartLabelResource> labels { get; set; }

        public string packingDescription { get; set; }

        public int? extraBuildWeeks { get; set; }

        public int? maximumOrderQuantity { get; set; }

        public OrderTypeResource orderType { get; set; }
    }
}
