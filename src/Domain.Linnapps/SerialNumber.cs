namespace Linn.Products.Domain.Linnapps
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    using Linn.Common.Domain.Exceptions;
    using Linn.Products.Domain.Linnapps.Products;

    public class SerialNumber
    {
        public SerialNumber(int sernosTref, string sernosGroup, string transCode)
        {
            this.ValidateSerialNumber(sernosGroup, transCode);

            this.SernosTref = sernosTref;
            this.SernosGroup = sernosGroup;
            this.TransCode = transCode;
        }

        public int? AccountId { get; set; }

        public string ArticleNumber { get; set; }

//        [ForeignKey("ARTICLE_NUMBER")]
        public SalesArticle SalesArticle { get; set; }

        public int CreatedBy { get; set; }

        public DateTime? DatePostedToVax { get; set; }

        public int? DocumentLine { get; set; }

        public int? DocumentNumber { get; set; }

        public string DocumentType { get; set; }

        public int? OutletNumber { get; set; }

        public int? PrevSernosNumber { get; set; }

        public DateTime? SernosDate { get; set; }

        public string SernosGroup { get; private set; }

        public int? SernosNumber { get; set; }

        public int SernosTref { get; private set; }

        public string TransCode { get; private set; }

        private void ValidateSerialNumber(string sernosGroup, string transCode)
        {
            if (string.IsNullOrEmpty(sernosGroup))
            {
                throw new DomainException("You must supply a sernos group");
            }

            if (string.IsNullOrEmpty(transCode))
            {
                throw new DomainException("You must supply a trans code");
            }
        }
    }
}