namespace Linn.Products.Domain.Linnapps
{
    using System;

    public class ArchiveSerialNumber
    {
        public string SernosGroup { get; set; }

        public int? SernosNumber { get; set; }

        public string TransCode { get; set; }

        public string ArticleNumber { get; set; }

        public DateTime? SernosDate { get; set; }

        public string DocumentType { get; set; }

        public int? DocumentNumber { get; set; }

        public int? DocumentLine { get; set; }

        public int? AccountId { get; set; }

        public int? OutletNumber { get; set; }

        public int? CreatedBy { get; set; }
    }
}
