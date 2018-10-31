namespace Linn.Products.Resources
{
    using Linn.Common.Resources;

    public class SernosConfigResource : HypermediaResource
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string SerialNumbered { get; set; }

        public int? NumberOfSernos { get; set; }

        public int? NumberOfBoxes { get; set; }

        public string StartOn { get; set; }
    }
}
