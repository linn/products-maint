namespace Linn.Products.Domain.Linnapps
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    using Linn.Products.Domain.Linnapps.Products;

    public class SaHoldStory
    {
        public SaHoldStory()
        {
            //ef
        }
        public int HoldStoryId { get; set; }

        [ForeignKey("ARTICLE_NUMBER")]
        public SalesArticle SalesArticle { get; set; }

        public DateTime DateStarted { get; set; }

        public DateTime? DateFinished { get; set; }

        [ForeignKey("EMPLOYEE_NUMBER")]
        public Employee PutOnHoldByEmployee { get; set; }

        public int? TakenOffHoldByEmployeeNumber { get; set; }

        public string ReasonStarted { get; set; }

        public string ReasonFinished { get; set; }

        public DateTime? AnticipatedEndDate { get; set; }

        public string RootProduct { get; set; }
    }
}
