namespace Linn.Products.Domain.Linnapps
{
    public class VatCode
    {
        public VatCode(string code, string description, double rate, string reason)
        {
            this.Code = code;
            this.Description = description;
            this.Rate = rate;
            this.Reason = reason;
        }

        public string Code { get; private set; }

        public string Description { get; set; }

        public double Rate { get; set; }

        public string Reason { get; set; }

        public void Update(string description, double rate, string reason = null)
        {
            this.Description = description;
            this.Rate = rate;
            this.Reason = reason;
        }
    }
}