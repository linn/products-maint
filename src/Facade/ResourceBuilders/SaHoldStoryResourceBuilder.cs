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

    public class SaHoldStoryResourceBuilder : IResourceBuilder<SaHoldStory>
    {
        public SaHoldStoryResource Build(SaHoldStory saHoldStory)
        {
            return new SaHoldStoryResource
            {
                           HoldStoryId = saHoldStory.HoldStoryId,
                           SalesArticle = saHoldStory.SalesArticle?.ArticleNumber,
                           DateStarted = saHoldStory.DateStarted.ToString("o"),
                           DateFinished = saHoldStory.DateFinished?.ToString("o"),
                           PutOnHoldByEmployee = saHoldStory.PutOnHoldByEmployee.FullName,
                           TakenOffHoldByEmployee = saHoldStory.TakenOffHoldByEmployee == null ? null : saHoldStory.TakenOffHoldByEmployee.FullName,
                           ReasonStarted = saHoldStory.ReasonStarted,
                           ReasonFinished = saHoldStory.ReasonFinished,
                           AnticipatedEndDate = saHoldStory.AnticipatedEndDate?.ToString("o"),  
                           RootProduct = saHoldStory.RootProduct?.Name,
                           Links = this.BuildLinks(saHoldStory).ToArray()
            };
        }

        object IResourceBuilder<SaHoldStory>.Build(SaHoldStory saHoldStory) => this.Build(saHoldStory);

        public string GetLocation(SaHoldStory model)
        {
            return $"/products/reports/sa-hold-stories/{model.HoldStoryId}";
        }

        private IEnumerable<LinkResource> BuildLinks(SaHoldStory story)
        {
            yield return new LinkResource
                             {
                                 Rel = "self",
                                 Href = this.GetLocation(story)
                             };
        }
    }
}
