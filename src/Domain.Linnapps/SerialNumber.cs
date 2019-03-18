namespace Linn.Products.Domain.Linnapps
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    using Linn.Common.Domain.Exceptions;
    using Linn.Products.Domain.Linnapps.Products;

    public class SerialNumber
    {
        public SerialNumber(int sernosNumber, string sernosGroup, string transCode)
        {
            this.ValidateSerialNumber(sernosNumber, sernosGroup, transCode);

            this.SernosNumber = sernosNumber;
            this.SernosGroup = sernosGroup;
            this.TransCode = transCode;
        }

        public int SernosTRef { get; set; }

        public string SernosGroup { get; private set; }

        public int SernosNumber { get; set; }

        public string TransCode { get; private set; }

        public int? AccountId { get; set; }

        public string ArticleNumber { get; set; }

        public SalesArticle SalesArticle { get; set; }

        public int CreatedBy { get; set; }

        public DateTime? DatePostedToVax { get; set; }

        public int? DocumentLine { get; set; }

        public int? DocumentNumber { get; set; }

        public string DocumentType { get; set; }

        public int? OutletNumber { get; set; }

        public int? PrevSernosNumber { get; set; }

        public DateTime? SernosDate { get; set; }

        private void ValidateSerialNumber(int serialNumber, string sernosGroup, string transCode)
        {
            if (serialNumber == 0)
            {
                throw new DomainException("You must supply a serial number");
            }

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