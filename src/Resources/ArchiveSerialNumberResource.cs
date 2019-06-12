namespace Linn.Products.Resources
{
    using Linn.Common.Resources;

    public class ArchiveSerialNumberResource : HypermediaResource
    {
        public string SernosGroup { get; set; }

        public int? SernosNumber { get; set; }

        public string TransCode { get; set; }

        public string ArticleNumber { get; set; }

        public string SernosDate { get; set; }

        public string DocumentType { get; set; }

        public int? DocumentNumber { get; set; }

        public int? DocumentLine { get; set; }

        public int? AccountId { get; set; }

        public int? OutletNumber { get; set; }

        public int? CreatedBy { get; set; }
    }
}
