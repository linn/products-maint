namespace Linn.Products.Facade.Services
{
    using System;
    using System.Linq.Expressions;

    using Linn.Common.Facade;
    using Linn.Common.Persistence;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    public class SaCoreTypeService : FacadeService<SaCoreType, int, SaCoreTypeResource, SaCoreTypeResource>
    {
        public SaCoreTypeService(IRepository<SaCoreType, int> repository, ITransactionManager transactionManager)
            : base(repository, transactionManager)
        {
        }

        protected override SaCoreType CreateFromResource(SaCoreTypeResource resource)
        {
            var coreType = new SaCoreType(
                resource.CoreType,
                resource.Description,
                string.IsNullOrEmpty(resource.DateInvalid) ? (DateTime?)null : DateTime.Parse(resource.DateInvalid),
                resource.LookAheadDays,
                resource.SortOrder,
                resource.TriggerLevel);

            return coreType;
        }

        protected override void UpdateFromResource(SaCoreType saCoreType, SaCoreTypeResource resource)
        {
            saCoreType.Update(
                resource.Description,
                string.IsNullOrEmpty(resource.DateInvalid) ? (DateTime?)null : DateTime.Parse(resource.DateInvalid),
                resource.LookAheadDays,
                resource.SortOrder,
                resource.TriggerLevel);
        }

        protected override Expression<Func<SaCoreType, bool>> SearchExpression(string searchTerm)
        {
            throw new NotImplementedException();
        }
    }
}
