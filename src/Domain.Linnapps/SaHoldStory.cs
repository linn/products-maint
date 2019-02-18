namespace Linn.Products.Domain.Linnapps
{
    using System;

    public class SaHoldStory
    {
        public int HoldStoryId { get; set; }

        public string ArticleNumber { get; set; }

        public DateTime DateStarted { get; set; }

        public DateTime? DateFinished { get; set; }

        public int PutOnHoldByEmployeeNumber { get; set; }

        public int? TakenOffHoldByEmployeeNumber { get; set; }

        public string ReasonStarted { get; set; }

        public string ReasonFinished { get; set; }

        public DateTime? AnticipatedEndDate { get; set; }

        public string RootProduct { get; set; }
    }
}
