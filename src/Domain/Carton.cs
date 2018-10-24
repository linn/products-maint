namespace Linn.Products.Domain
{
    using System;

    public class Carton : Entity
    {
        public Carton(string name, double width, double depth, double height)
        {
            this.Name = name;
            this.Width = width;
            this.Depth = depth;
            this.Height = height;
        }

        private Carton()
        {
            // ef
        }

        public double Depth { get; set; }

        public double Height { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Volume => this.Width * this.Depth * this.Height;

        public double Width { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public string PhasedOutBy { get; set; }

        public DateTime? PhasedOutOn { get; set; }
    }
}