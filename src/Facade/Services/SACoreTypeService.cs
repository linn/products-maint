namespace Linn.Products.Facade.Services
{
    using System;

    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Persistence.Linnapps;
    using Linn.Products.Resources;

    public class SaCoreTypeService : FacadeService<SaCoreType, int, SaCoreTypeResource>
    {
        private readonly IRepository<SaCoreType, int> repository;

        public SaCoreTypeService(IRepository<SaCoreType, int> repository) : base(repository)
        {
            this.repository = repository;
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
    }
}
