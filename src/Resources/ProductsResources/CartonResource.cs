namespace Linn.Products.Resources.ProductsResources
{
    using Linn.Common.Configuration;

    public class CartonResource : PhaseOutableEntityResource
    {
        public double depth { get; set; }

        public double height { get; set; }

        public string href
        {
            get
            {
                var appRoot = ConfigurationManager.Configuration["APP_ROOT"];
                return $"{appRoot}/cartons/{this.id}";
            }
        }

        public string name { get; set; }

        public string description { get; set; }

        public double volume { get; set; }

        public double width { get; set; }
    }
}
