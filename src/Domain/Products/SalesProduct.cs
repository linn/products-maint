namespace Linn.Products.Domain.Products
{
    using System;

    using Linn.Common.Domain.Exceptions;

    public class SalesProduct : PhaseOutableEntity, IProductEntity
    {
        public SalesProduct(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new DomainException("A sales product must have a name");
            }

            this.Name = name;
        }

        public SalesProduct()
        {
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public ProductRange ProductRange { get; set; }

        public DateTime? PhasedInOn { get; set; }

        public bool DisplayOnTradeSite { get; set; }

        public void UpdateSalesProduct(SalesProduct updatedSalesProduct)
        {
            this.Name = updatedSalesProduct.Name;
            this.Description = updatedSalesProduct.Description;
            this.ProductRange = updatedSalesProduct.ProductRange;
            this.PhasedInOn = updatedSalesProduct.PhasedInOn;
            this.DisplayOnTradeSite = updatedSalesProduct.DisplayOnTradeSite;
            if (updatedSalesProduct.PhasedOutOn != null)
            {
                if (this.PhasedOutOn?.Date != updatedSalesProduct.PhasedOutOn?.Date)
                {
                    this.PhasedOutBy = updatedSalesProduct.PhasedOutBy;
                    this.PhasedOutOn = updatedSalesProduct.PhasedOutOn;
                }
            }
            else
            {
                this.PhasedOutBy = null;
                this.PhasedOutOn = null;
            }
        }

        public T Accept<T>(IProductEntityVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}
