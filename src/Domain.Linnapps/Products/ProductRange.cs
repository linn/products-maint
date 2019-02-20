namespace Linn.Products.Domain.Linnapps.Products
{
    using System;

    public class ProductRange
    {
        public int Id { get; set; }

        public string RangeName { get; set; }

        public string RangeDescription { get; set; }

        public DateTime? DateInvalid { get; set; }
    }
}
