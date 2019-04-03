namespace Linn.Products.Facade.ResourceBuilders
{
    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    public class SaHoldStoryResourceBuilder : IResourceBuilder<SaHoldStory>
    {
        public SaHoldStoryResource Build(SaHoldStory saHoldStory)
        {
            return new SaHoldStoryResource
                       {
                           HoldStoryId = saHoldStory.HoldStoryId,
                           ArticleNumber = saHoldStory.SalesArticle.ArticleNumber,
                           DateStarted = saHoldStory.DateStarted.ToString("o"),
                           DateFinished = saHoldStory.DateFinished?.ToString("o"),
                           PutOnHoldByEmployee = saHoldStory.PutOnHoldByEmployee.FullName,
                           TakenOffHoldByEmployee = saHoldStory.TakenOffHoldByEmployee == null ? null : saHoldStory.TakenOffHoldByEmployee.FullName,
                           ReasonStarted = saHoldStory.ReasonStarted,
                           ReasonFinished = saHoldStory.ReasonFinished,
                           AnticipatedEndDate = saHoldStory.AnticipatedEndDate?.ToString("o"),  
                           RootProduct = saHoldStory.SalesArticle.RootProduct
            };
        }

        object IResourceBuilder<SaHoldStory>.Build(SaHoldStory saHoldStory) => this.Build(saHoldStory);

        public string GetLocation(SaHoldStory model)
        {
            return $"/products/reports/sa-hold-stories/{model.HoldStoryId}";
        }
    }
}
