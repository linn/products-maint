namespace Linn.Products.Facade.Services
{
    using System;
    using System.Linq.Expressions;

    using Linn.Common.Facade;
    using Linn.Common.Persistence;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    public class SaHoldStoryFacadeService : FacadeService<SaHoldStory, int, SaHoldStoryResource, SaHoldStoryResource>
    {
        public SaHoldStoryFacadeService(IRepository<SaHoldStory, int> repo, ITransactionManager transactionManager)
            : base(repo, transactionManager)
        {
        }

        protected override SaHoldStory CreateFromResource(SaHoldStoryResource resource)
        {
            throw new System.NotImplementedException();
        }

        protected override void UpdateFromResource(SaHoldStory entity, SaHoldStoryResource updateResource)
        {
            throw new System.NotImplementedException();
        }

        protected override Expression<Func<SaHoldStory, bool>> SearchExpression(string searchTerm)
        {
            throw new NotImplementedException();
        }
    }
}
