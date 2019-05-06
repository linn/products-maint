namespace Linn.Products.Domain.Linnapps.SernosTransactions
{
    public class SernosTransCount
    {
        public string TransCode { get; set; }

        public string SernosCount { get; set; }

        public string CheckError { get; set; }

        public int? CorrectValue { get; set; }

        public int? CountIncrement { get; set; }

        public string CheckErrorMess { get; set; }

        public SernosTrans SernosTrans { get; set; }
    }
}