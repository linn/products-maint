namespace Linn.Products.Resources.ProductsResources
{
    using Linn.Common.Configuration;

    public class TypeOfSerialNumberResource : EntityResource
    {
        public string href
        {
            get
            {
                var appRoot = ConfigurationManager.Configuration["APP_ROOT"];
                return $"{appRoot}/types-of-serial-number/{this.id}";
            }
        }

        public string name { get; set; }

        public string description { get; set; }

        public int numberOfSerialNumbers { get; set; }

        public int numberOfBoxes { get; set; }
    }
}