namespace Linn.Products.Facade.ResourceBuilders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Linn.Common.Facade;
    using Linn.Common.Resources;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Resources;

    public class RootProductResourceBuilder : IResourceBuilder<RootProduct>
    {
        public RootProductResource Build(RootProduct rootProduct)
        {
            return new RootProductResource
                       {
                           Name = rootProduct.Name,
                           Description = rootProduct.Description,
                           Links = this.BuildLinks(rootProduct).ToArray(),
                           onHold = isOnHold(rootProduct)
                       };
        }

        object IResourceBuilder<RootProduct>.Build(RootProduct r) => this.Build(r);

        public string GetLocation(RootProduct rootProduct)
        {
            return $"/products/maint/root-products/{Uri.EscapeDataString(rootProduct.Name)}";
        }

        private static bool isOnHold(RootProduct rootProduct)
        {
            return rootProduct.HoldStories?.Any(story => story.DateFinished == null) ?? false;

        }
        private IEnumerable<LinkResource> BuildLinks(RootProduct rootProduct)
        {
            var openStory = rootProduct.HoldStories?.FirstOrDefault(s => s.DateFinished == null);

            yield return new LinkResource
                             {
                                 Rel = "self",
                                 Href = this.GetLocation(rootProduct)
                             };

            yield return new LinkResource
                             {
                                 Rel = "put-on-hold",
                                 Href = $"{this.GetLocation(rootProduct)}/put-on-hold"
                             };
            if (openStory != null)
            {
                yield return new LinkResource
                                    {
                                        Rel = "put-off-hold",
                                        Href = $"/products/maint/close-hold-story/{openStory.HoldStoryId}"
                };
            }
        }
    }
}
