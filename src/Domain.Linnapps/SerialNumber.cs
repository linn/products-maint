﻿namespace Linn.Products.Domain.Linnapps
{
    using System;

    using Linn.Common.Domain.Exceptions;
    using Linn.Products.Domain.Linnapps.Products;

    public class SerialNumber
    {
        public SerialNumber(int sernosTRef, string sernosGroup, string transCode, string articleNumber, int createdBy)
        {
            this.ValidateSerialNumber(sernosGroup, transCode, articleNumber);

            this.SernosTRef = sernosTRef;
            this.SernosGroup = sernosGroup;
            this.TransCode = transCode;
            this.ArticleNumber = articleNumber;
            this.CreatedBy = createdBy;
        }

        public int SernosTRef { get; set; }

        public string SernosGroup { get; private set; }

        public int SernosNumber { get; set; }

        public string TransCode { get; private set; }

        public int? AccountId { get; set; }

        public string ArticleNumber { get; set; }
        
        public int CreatedBy { get; set; }

        public DateTime? DatePostedToVax { get; set; }

        public int? DocumentLine { get; set; }

        public int? DocumentNumber { get; set; }

        public string DocumentType { get; set; }

        public int? OutletNumber { get; set; }

        public int? PrevSernosNumber { get; set; }

        public DateTime? SernosDate { get; set; }

        public SernosNote SernosNote { get; set; }

        private void ValidateSerialNumber(string sernosGroup, string transCode, string articleNumber)
        {
            if (string.IsNullOrEmpty(sernosGroup))
            {
                throw new DomainException("You must supply a sernos group");
            }

            if (string.IsNullOrEmpty(transCode))
            {
                throw new DomainException("You must supply a trans code");
            }

            if (string.IsNullOrEmpty(articleNumber))
            {
                throw new DomainException("You must supply an artile number");
            }
        }
    }
}