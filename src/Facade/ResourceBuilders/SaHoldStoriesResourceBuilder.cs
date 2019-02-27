namespace Linn.Products.Facade.ResourceBuilders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    public class SaHoldStoriesResourceBuilder : IResourceBuilder<IEnumerable<SaHoldStory>>
    {
        private readonly SaHoldStoryResourceBuilder saHoldStoryResourceBuilder = new SaHoldStoryResourceBuilder();

        public IEnumerable<SaHoldStoryResource> Build(IEnumerable<SaHoldStory> saHoldStories)
        {
            return saHoldStories.Select(a => this.saHoldStoryResourceBuilder.Build(a));
        }

        object IResourceBuilder<IEnumerable<SaHoldStory>>.Build(IEnumerable<SaHoldStory> saHoldStories) =>
            this.Build(saHoldStories);

        public string GetLocation(IEnumerable<SaHoldStory> saHoldStories)
        {
            throw new NotImplementedException();
        }
    }
}