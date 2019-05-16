namespace Linn.Products.Resources
{
    using System.Collections.Generic;

    using Linn.Common.Resources;

    public class SernosTransactionResource : HypermediaResource
    {
        public string TransCode { get; set; }

        public string TransDescription { get; set; }

        public string Comments { get; set; }

        public string ManualPost { get; set; }

        public string UpdateLastTransaction { get; set; }

        public string UpdateBuiltBy { get; set; }

        public string UpdateLastAccount { get; set; }

        public IEnumerable<SernosTransactionCountResource> SernosTransCounts { get; set; }
    }
}
