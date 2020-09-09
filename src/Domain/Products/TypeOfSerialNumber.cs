namespace Linn.Products.Domain.Products
{
    public class TypeOfSerialNumber : Entity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int NumberOfSerialNumbers { get; set; }

        public int NumberOfBoxes { get; set; }
    }
}