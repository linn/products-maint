namespace Linn.Products.Domain.Products
{
    public class Carton : PhaseOutableEntity
    {
        public Carton(string name, double width, double depth, double height)
        {
            this.Name = name;
            this.Width = width;
            this.Depth = depth;
            this.Height = height;
        }

        public Carton()
        {
        }

        public double Depth { get; set; }

        public double Height { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Volume => this.Width * this.Depth * this.Height;

        public double Width { get; set; }
    }
}