namespace Linn.Products.Resources
{
    using Linn.Common.Resources;

    public class SerialNumberCreateResource : HypermediaResource
    {
        public string ArticleNumber { get; set; }

        public int CreatedBy { get; set; }

        public int FromSernosNumber { get; set; }

        public int ToSernosNumber { get; set; }

        public int? PrevSernosNumber { get; set; }

        public string SernosGroup { get; set; }

        public string TransCode { get; set; }

        public string SernosNotes { get; set; }
    }
}