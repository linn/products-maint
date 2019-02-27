namespace Linn.Products.Service.ResponseProcessors
{
    using System.Collections.Generic;

    using Linn.Common.Facade;
    using Linn.Common.Nancy.Facade;
    using Linn.Products.Domain.Linnapps;

    public class SaHoldStoriesResponseProcessor : JsonResponseProcessor<IEnumerable<SaHoldStory>>
    {
        public SaHoldStoriesResponseProcessor(IResourceBuilder<IEnumerable<SaHoldStory>> resourceBuilder)
            : base(resourceBuilder, "sa-hold-stories", 1)
        {
        }
    }
}