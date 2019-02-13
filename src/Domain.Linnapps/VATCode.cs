namespace Linn.Products.Domain.Linnapps
{
    public class VatCode
    {
        public VatCode(string code, string description, double rate, string reason, string vatOnly, int? vatReturnId)
        {
            this.Code = code;
            this.Description = description;
            this.Rate = rate;
            this.Reason = reason;
            this.VatOnly = vatOnly;
            this.VatReturnId = vatReturnId;
        }

        public string Code { get; private set; }

        public string Description { get; set; }

        public double Rate { get; set; }

        public string Reason { get; set; }

        public string VatOnly { get; set; }

        public int? VatReturnId { get; set; }

        public void Update(string description, double rate, string reason, string vatOnly, int? vatReturnId)
        {
            this.Description = description;
            this.Rate = rate;
            this.Reason = reason;
            this.VatOnly = vatOnly;
            this.VatReturnId = vatReturnId;
        }
    }
}