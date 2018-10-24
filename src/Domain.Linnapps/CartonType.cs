namespace Linn.Products.Domain.Linnapps
{
    using Linn.Products.Domain.Linnapps.Exceptions;

    public class CartonType
    {
        public CartonType(string name, decimal width, decimal height, decimal depth)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new IncompleteDataException("A carton type must have a name");
            }

            if (width <= 0 || height <= 0 || depth <= 0)
            {
                throw new IncompleteDataException("A carton type must have valid dimensions");
            }

            this.Name = name;
            this.Width = width;
            this.Height = height;
            this.Depth = depth;
        }

        private CartonType()
        {
            // ef
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Height { get; set; }

        public decimal Width { get; set; }

        public decimal Depth { get; set; }

        public int NumberOfSmallLabels { get; set; }

        public int NumberOfLargeLabels { get; set; }
    }
}
