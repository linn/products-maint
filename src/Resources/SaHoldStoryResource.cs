﻿namespace Linn.Products.Resources
{
    using Linn.Common.Resources;

    public class SaHoldStoryResource : HypermediaResource
    {
        public int HoldStoryId { get; set; }

        public string SalesArticle { get; set; }

        public string DateStarted { get; set; }

        public string DateFinished { get; set; }

        public string PutOnHoldByEmployee { get; set; }

        public string TakenOffHoldByEmployee { get; set; }

        public string ReasonStarted { get; set; }

        public string ReasonFinished { get; set; }

        public string AnticipatedEndDate { get; set; }

        public string RootProduct { get; set; }
    }
}
