namespace Linn.Products.Domain.Products
{
    using System;

    public class Bundle : IProductEntity
    {
        public Bundle(string href, string name, string description, DateTime createdOn, DateTime? phasedOutOn)
        {
            this.Href = href;
            this.Name = name;
            this.Description = description;
            this.CreatedOn = createdOn;
            this.PhasedOutOn = phasedOutOn;
        }

        public string Href { get; }

        public string Name { get; }

        public string Description { get; }

        public DateTime CreatedOn { get; }

        public DateTime? PhasedOutOn { get; }

        public T Accept<T>(IProductEntityVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}