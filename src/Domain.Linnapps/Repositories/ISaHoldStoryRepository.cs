namespace Linn.Products.Domain.Linnapps.Repositories
{
    using System.Collections.Generic;

    public interface ISaHoldStoryRepository
    {
        IEnumerable<SaHoldStory> GetSaHoldStories();
    }
}
