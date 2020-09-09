namespace Linn.Products.Domain.Products
{
    public class ProcommCategory : PhaseOutableEntity, IProductEntity
    {
        public ProcommCategory(string description)
        {
            this.Description = description;
        }

        public ProcommCategory()
        {
        }

        public string Description { get; set; }

        public string Name
        {
            get
            {
                return this.Description;
            }
        }

        public T Accept<T>(IProductEntityVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}
