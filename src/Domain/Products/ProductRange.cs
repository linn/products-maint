namespace Linn.Products.Domain.Products
{
    public class ProductRange : PhaseOutableEntity, IProductEntity
    {
        public ProductRange(string name)
        {
            this.Name = name;
        }

        public ProductRange()
        {
            // nhibernate
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public T Accept<T>(IProductEntityVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}
