namespace Linn.Products.Domain.Products
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    using Linn.Products.Domain.Products.Labels;

    public class ProductSalesPart : SalesPartBase, IProductEntity
    {
        private readonly IDictionary<string, ISalesPartLabel> labels = new Dictionary<string, ISalesPartLabel>();
        
        private Carton carton;

        private string unitedStatesTariffCode;

        private ProductSalesPart replacedByPart;

        [ForeignKey("ROOTPRODUCT_ID")]
        public RootProduct RootProduct { get; set; }

        public bool ExDem { get; set; }

        public string BarcodePrefix { get; set; }

        public string Ean { get; private set; }

        [ForeignKey("REPLACEDBYPART_ID")]
        public ProductSalesPart ReplacedByPart
        {
            get => this.replacedByPart;

            set
            {
                if (value?.ReplacedByPart != null)
                {
                    value.replacedByPart = null;
                }

                this.replacedByPart = value;
            }
        }

        public double? WeightInKg { get; set; }

        [ForeignKey("CIT_ID")]
        public Cit Cit { get; set; }

        [ForeignKey("TARIFF_ID")]
        public Tariff Tariff { get; set; }

        public Uri CountryOfOrigin { get; set; }

        public TypeOfSerialNumber TypeOfSerialNumber { get; set; }

        [ForeignKey("SERIALNUMBERSOURCE_ID")]
        public SerialNumberSource SerialNumberSource { get; set; }

        public int? ExtraBuildWeeks { get; set; }

        [ForeignKey("ORDERTYPE_ID")]
        public OrderType OrderType { get; set; }

        public int? MaximumOrderQuantity { get; set; }

        public double? NettWeight { get; set; }

        public bool WeeeProduct { get; set; }

        public bool DimensionOver50Cm { get; set; }

        public string WeeeCategory { get; set; }

        public int? MainsCablesPerProduct { get; set; }

        public double? PackagingNettWeight { get; set; }

        public double? PackagingFoamNettWeight { get; set; }

        public string UnitedStatesTariffCode
        {
            get => this.unitedStatesTariffCode ?? this.Tariff?.UsTariffCode;

            set
            {
                // we should inherit the us tariff code from the uk tariff if they are the same
                if (this.Tariff != null && this.Tariff.UsTariffCode == value)
                {
                    this.unitedStatesTariffCode = null;
                }
                else
                {
                    this.unitedStatesTariffCode = value;
                }
            }
        }

        [ForeignKey("CARTON_ID")]
        public Carton Carton
        {
            get => this.carton ?? this.RootProduct?.Carton;

            set
            {
                if (this.RootProduct?.Carton != null && this.RootProduct.Carton.Equals(value))
                {
                    // we should inherit the carton from the root product if they are the same
                    this.carton = null;
                }
                else
                {
                    this.carton = value;
                }
            }
        }
        
        public IEnumerable<ISalesPartLabel> Labels => this.labels.Values;

        public ISalesPartLabel AddLabel(string labelType, ISalesPartLabel label)
        {
            this.labels[labelType] = label;
            return label;
        }

        public void RemoveLabel(string labelType)
        {
            this.labels.Remove(labelType);
        }

        public bool HasLabel(string labelType)
        {
            return this.labels.ContainsKey(labelType);
        }

        public ISalesPartLabel GetLabel(string labelType)
        {
            return this.labels[labelType];
        }

        public T Accept<T>(IProductEntityVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }

        public void SetEan(string prefix, string sequence)
        {
            this.Ean = prefix + sequence + GetEanCheckDigit(prefix + sequence);
        }

        private static int GetEanCheckDigit(string eanCode)
        {
            var total = ((
                            int.Parse(eanCode.Substring(1, 1)) +
                            int.Parse(eanCode.Substring(3, 1)) +
                            int.Parse(eanCode.Substring(5, 1)) +
                            int.Parse(eanCode.Substring(7, 1)) +
                            int.Parse(eanCode.Substring(9, 1)) +
                            int.Parse(eanCode.Substring(11, 1))) * 3) +
                            int.Parse(eanCode.Substring(0, 1)) +
                            int.Parse(eanCode.Substring(2, 1)) +
                            int.Parse(eanCode.Substring(4, 1)) +
                            int.Parse(eanCode.Substring(6, 1)) +
                            int.Parse(eanCode.Substring(8, 1)) +
                            int.Parse(eanCode.Substring(10, 1));
            var digit = 10 - (total % 10);
            return digit % 10;
        }
    }
}
