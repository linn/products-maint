namespace Linn.Products.Resources
{
    public class SernosTransactionCountResource
    {
        public string TransCode { get; set; }

        public string SernosCount { get; set; }

        public string CheckError { get; set; }

        public int? CorrectValue { get; set; }

        public int? CountIncrement { get; set; }

        public string CheckErrorMess { get; set; }
    }
}