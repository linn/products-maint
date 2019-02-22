namespace Linn.Products.Domain.Linnapps.Products
{
    using System;

    using Linn.Common.Domain.Exceptions;

    public class ProductRange
    {
        public int Id { get; set; }

        public string RangeName { get; set; }

        public string RangeDescription { get; set; }

        public DateTime? DateInvalid { get; set; }

        public void ValidateProductRange()
        {
            if (string.IsNullOrEmpty(this.RangeName))
            {
                throw new DomainException("You must supply a name for a product range");
            }

            if (string.IsNullOrEmpty(this.RangeDescription))
            {
                throw new DomainException("You must supply a description from a product range");
            }
        }
    }
}
