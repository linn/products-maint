namespace Linn.Products.Domain.Products
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class RootProduct : PhaseOutableEntity, IProductEntity
    {
        private string name;

        public RootProduct(string name)
        {
            this.Name = name;
        }

        public RootProduct()
        {
        }

        public string Name
        {
            get => this.name;
            set => this.name = value.ToUpper();
        }
        
        public string Description { get; set; }

        public Carton Carton { get; set; }

        public SalesProduct SalesProduct { get; set; }

        public bool HasSerialNumberOnBoard { get; set; }

        public ProcommCategory ProcommCategory { get; set; }

        public T Accept<T>(IProductEntityVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}
