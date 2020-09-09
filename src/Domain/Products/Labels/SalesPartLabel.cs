namespace Linn.Products.Domain.Products.Labels
{
    public abstract class SalesPartLabel : ISalesPartLabel
    {
        public virtual string Type { get; set; }

        public virtual int Id { get; set; }

        public virtual int NumberToBePrinted { get; set; }

        public abstract T Accept<T>(ISalesPartLabelVisitor<T> visitor);
    }
}