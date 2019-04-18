namespace Linn.Products.Domain.Linnapps
{
    public class SernosTrans
    {
        public string TransCode { get; set; }

        public string TransDescription { get; set; }

        public string Comments { get; set; }

        public string ManualPost { get; set; }

        public int? NettBuilds { get; set; }

        public int? NettIssues { get; set; }

        public int? NettSales { get; set; }

        public int? NettMoves { get; set; }

        public int? NettLoans { get; set; }

        public int? NettSteals { get; set; }

        public int? NettScraps { get; set; }

        public string UpdateLastTransaction { get; set; }

        public string UpdateBuiltBy { get; set; }

        public string UpdateLastAccount { get; set; }

        public string LastTransCheck { get; set; }

        public string CheckLastTransCode { get; set; }

        public string LastTransCheckMess { get; set; }

        public string SameDocumentCheck { get; set; }

        public string SameDocumentCheckMess { get; set; }

        public string SameDoclineCheck { get; set; }

        public string SameDoclineCheckMess { get; set; }

        public string SameAccountCheck { get; set; }

        public string SameAccountCheckMess { get; set; }

        public string SameOutletCheck { get; set; }

        public string SameOutletCheckMess { get; set; }

        public string AuthOperation { get; set; }
    }
}
