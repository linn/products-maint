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
                           ArticleNumber = saHoldStory.ArticleNumber,
                           DateStarted = saHoldStory.DateStarted,
                           DateFinished = saHoldStory.DateFinished,
                           PutOnHoldByEmployeeNumber = saHoldStory.PutOnHoldByEmployeeNumber,
                           TakenOffHoldByEmployeeNumber = saHoldStory.TakenOffHoldByEmployeeNumber,
                           ReasonStarted = saHoldStory.ReasonStarted,
                           ReasonFinished = saHoldStory.ReasonFinished,
                           AnticipatedEndDate = saHoldStory.AnticipatedEndDate,  
                           RootProduct = saHoldStory.RootProduct
                       };
        }

        object IResourceBuilder<SaHoldStory>.Build(SaHoldStory saHoldStory) => this.Build(saHoldStory);

        public string GetLocation(SaHoldStory model)
        {
            return $"/products/maint/sa-hold-stories/{model.HoldStoryId}";
        }
    }
}
