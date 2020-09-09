namespace Linn.Products.Domain.Products
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public abstract class SalesPartBase : PhaseOutableEntity
    {
        private readonly IList<AttributeValue> attributes = new List<AttributeValue>();

        private string name;

        private string shortDescription;

        public string Name
        {
            get => this.name;
            set => this.name = value.ToUpper();
        }

        [ForeignKey("TYPEOFSALE_ID")]
        public TypeOfSale TypeOfSale { get; set; }

        public DateTime? PhasedInOn { get; set; }

        public string Description { get; set; }

        public int MinimumOrderQuantity { get; set; }

        public string Notes { get; private set; }

        public string OrderInformation { get; private set; }

        public IEnumerable<AttributeValue> Attributes => this.attributes;

        public int OrderMultiple { get; set; }

        public string ShortDescription
        {
            get => string.IsNullOrEmpty(this.shortDescription) ? this.Description : this.shortDescription;

            set => this.shortDescription = value;
        }

        public VatCode VatCode { get; set; }

        public AccountingCompany AccountingCompany { get; set; }

        public bool SetNotes(string text)
        {
            if (text != null && text.Length > 2000)
            {
                return false;
            }

            this.Notes = text;
            return true;
        }

        public bool SetOrderInformation(string text)
        {
            if (text != null && text.Length > 2000)
            {
                return false;
            }

            this.OrderInformation = text;
            return true;
        }

        public void AddAttribute(AttributeKey key, string value)
        {
            this.attributes.Add(new AttributeValue { Key = key, Value = value });
        }

        public void AddAttribute(AttributeValue attributeValue)
        {
            this.attributes.Add(attributeValue);
        }

        public void ReplaceOrAddAttribute(AttributeValue attributeValue)
        {
            var attribute = this.Attributes.FirstOrDefault(a => a.Key.Id == attributeValue.Key.Id);
            if (attribute != null)
            {
                this.attributes.Remove(attribute);
            }

            this.attributes.Add(attributeValue);
        }

        public void ReplaceOrAddAttribute(AttributeKey key, string value)
        {
            var attribute = this.Attributes.FirstOrDefault(a => a.Key.Name == key.Name);
            if (attribute != null)
            {
                this.attributes.Remove(attribute);
            }

            this.attributes.Add(new AttributeValue { Key = key, Value = value });
        }
    }
}
