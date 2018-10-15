namespace Linn.Products.Resources
{
    public class CartonTypeResource : CartonTypeUpdateResource
    {
        public string Name { get; set; }

        public int NumberOfSmallLabels { get; set; }

        public int NumberOfLargeLabels { get; set; }
    }
}
