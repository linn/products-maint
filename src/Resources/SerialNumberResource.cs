namespace Linn.Products.Resources
{
    using Linn.Common.Resources;

    public class SerialNumberResource : HypermediaResource
    {
        public string ArticleNumber { get; set; }

        public int? DocumentNumber { get; set; }

        public string DocumentType { get; set; }

        public int? PrevSernosNumber { get; set; }

        public string SernosDate { get; set; }

        public string SernosGroup { get; set; }

        public int SernosNumber { get; set; }

        public int SernosTRef { get; set; }

        public string TransCode { get; set; }
    }
}