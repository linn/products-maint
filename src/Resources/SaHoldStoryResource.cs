using System;
using System.Collections.Generic;
using System.Text;

namespace Linn.Products.Resources
{
    using Linn.Common.Resources;

    public class SaHoldStoryResource : HypermediaResource
    {
        public int HoldStoryId { get; set; }

        public string ArticleNumber { get; set; }

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
