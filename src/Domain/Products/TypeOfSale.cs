namespace Linn.Products.Domain.Products
{
    public class TypeOfSale : PhaseOutableEntity
    {
        public TypeOfSale(string name)
        {
            this.Name = name;
        }

        public TypeOfSale()
        {
        }

        public string Description { get; set; }

        public string Name { get; set; }
    }
}
