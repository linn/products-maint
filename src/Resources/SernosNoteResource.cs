namespace Linn.Products.Resources
{
    using Linn.Common.Resources;

    public class SernosNoteResource : HypermediaResource
    {
        public string SernosGroup { get; set; }

        public int SernosNoteId { get; set; }

        public string SernosNotes { get; set; }

        public int? SernosNumber { get; set; }

        public int? SernosTref { get; set; }

        public string TransCode { get; set; }
    }
}