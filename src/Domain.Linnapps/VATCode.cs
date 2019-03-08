namespace Linn.Products.Domain.Linnapps
{
    using Linn.Common.Domain.Exceptions;

    public class VatCode
    {
        public VatCode(string code, string description, decimal rate, string reason, int? vatReturnId, string vatOnly)
        {
            this.ValidateVatCode(code, description);

            this.Code = code;
            this.Description = description;
            this.Rate = rate;
            this.Reason = reason;
            this.VatOnly = vatOnly;
            this.VatReturnId = vatReturnId;
        }

        public string Code { get; private set; }

        public string Description { get; set; }

        public decimal Rate { get; set; }

        public string Reason { get; set; }

        public string VatOnly { get; set; }

        public int? VatReturnId { get; set; }

        public void Update(string code, string description, decimal rate, string reason, int? vatReturnId, string vatOnly)
        {
            this.ValidateVatCode(code, description);

            this.Description = description;
            this.Rate = rate;
            this.Reason = reason;
            this.VatOnly = vatOnly;
            this.VatReturnId = vatReturnId;
        }

        private void ValidateVatCode(string code, string description)
        {
            if (string.IsNullOrEmpty(code))
            {
                throw new DomainException("You must supply a code");
            }

            if (string.IsNullOrEmpty(description))
            {
                throw new DomainException("You must supply a description");
            }
        }
    }
}