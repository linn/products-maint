namespace Linn.Products.Domain.Linnapps.SernosTransactions
{
    using System.Collections.Generic;

    public class SernosTrans
    {
        public string TransCode { get; set; }

        public string TransDescription { get; set; }

        public string Comments { get; set; }

        public string ManualPost { get; set; }

        public string UpdateLastTransaction { get; set; }

        public string UpdateBuiltBy { get; set; }

        public string UpdateLastAccount { get; set; }

        public ICollection<SernosTransCount> SernosTransCounts { get; set; } = new List<SernosTransCount>();
    }
}