namespace Linn.Products.Facade.Services
{
    using Linn.Common.Facade;
    using Linn.Common.Persistence;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Domain.Linnapps.Repositories;
    using Linn.Products.Resources;

    public class SaHoldStoryService : FacadeService<SaHoldStory, int, SaHoldStoryResource, SaHoldStoryResource>
    {
        public SaHoldStoryService(IRepository<SaHoldStory, int> repo, ITransactionManager transactionManager)
            : base(repo, transactionManager)
        {
        }

        protected override SaHoldStory CreateFromResource(SaHoldStoryResource resource)
        {
            return new SaHoldStory()
                       {
                           HoldStoryId = resource.HoldStoryId,
                           ArticleNumber = resource.ArticleNumber,
                           DateStarted = resource.DateStarted,
                           DateFinished = resource.DateFinished,
                           PutOnHoldByEmployeeNumber = resource.PutOnHoldByEmployeeNumber,
                           TakenOffHoldByEmployeeNumber = resource.TakenOffHoldByEmployeeNumber,
                           ReasonStarted = resource.ReasonStarted,
                           ReasonFinished = resource.ReasonFinished,
                           AnticipatedEndDate = resource.AnticipatedEndDate,
                           RootProduct = resource.RootProduct
                        };
        }

        protected override void UpdateFromResource(SaHoldStory entity, SaHoldStoryResource updateResource)
        {
            throw new System.NotImplementedException();
        }
    }
}
