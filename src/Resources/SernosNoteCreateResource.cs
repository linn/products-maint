namespace Linn.Products.Resources
{
    using Linn.Common.Resources;

    public class SernosNoteCreateResource : HypermediaResource
    {
        public string SernosGroup { get; set; }

        public string SernosNotes { get; set; }

        public int? SernosNumber { get; set; }

        public int? SernosTRef { get; set; }

        public string TransCode { get; set; }
    }
}