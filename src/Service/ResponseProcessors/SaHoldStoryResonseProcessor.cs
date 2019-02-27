namespace Linn.Products.Service.ResponseProcessors
{
    using Linn.Common.Facade;
    using Linn.Common.Nancy.Facade;
    using Linn.Products.Domain.Linnapps;

    public class SaHoldStoryResponseProcessor : JsonResponseProcessor<SaHoldStory>
    {
        public SaHoldStoryResponseProcessor(IResourceBuilder<SaHoldStory> resourceBuilder)
            : base(resourceBuilder, "sa-hold-story", 1)
        {
        }
    }
}