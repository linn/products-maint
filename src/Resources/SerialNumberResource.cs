namespace Linn.Products.Resources
{
    using Linn.Common.Resources;
    using Linn.Products.Domain.Linnapps;

    public class SerialNumberResource : HypermediaResource
    {
        public int? AccountId { get; set; }

        public string ArticleNumber { get; set; }

        public int CreatedBy { get; set; }

        public string DatePostedToVax { get; set; }

        public int? DocumentLine { get; set; }

        public int? DocumentNumber { get; set; }

        public string DocumentType { get; set; }

        public int? OutletNumber { get; set; }

        public int? PrevSernosNumber { get; set; }

        public string SernosDate { get; set; }

        public string SernosGroup { get; set; }

        public int? SernosNumber { get; set; }

        public int SernosTRef { get; set; }

        public SernosNote SernosNote { get; set; }

        public string TransCode { get; set; }
    }
}