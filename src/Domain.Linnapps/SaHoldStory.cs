namespace Linn.Products.Domain.Linnapps
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    using Linn.Products.Domain.Linnapps.Products;

    public class SaHoldStory
    {
        public int HoldStoryId { get; set; }

        public SalesArticle SalesArticle { get; set; }

        public string ArticleNumber { get; set; }

        public DateTime DateStarted { get; set; }

        public DateTime? DateFinished { get; set; }

        [ForeignKey("EMPLOYEE_NUMBER")]
        public Employee PutOnHoldByEmployee { get; set; }

        [ForeignKey("EMPLOYEE_NUMBER_TAKEN_OFF_HOLD")]
        public Employee TakenOffHoldByEmployee { get; set; }

        public string ReasonStarted { get; set; }

        public string ReasonFinished { get; set; }

        public DateTime? AnticipatedEndDate { get; set; }

        public string RootProduct { get; set; }
    }
}
