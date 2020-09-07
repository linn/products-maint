namespace Linn.Products.Facade.Services
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using Linn.Common.Facade;
    using Linn.Common.Persistence;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Facade.Extensions;
    using Linn.Products.Resources;

    public class TariffService : FacadeService<Tariff, int, TariffResource, TariffResource>
    {
        private readonly IRepository<Tariff, int> repository;

        public TariffService(IRepository<Tariff, int> repository, ITransactionManager transactionManager)
            : base(repository, transactionManager)
        {
            this.repository = repository;
        }

        protected override Tariff CreateFromResource(TariffResource resource)
        {
            return new Tariff
            {
                TariffCode = resource.TariffCode,
                Description = resource.Description,
                USTariffCode = resource.USTariffCode,
                DateInvalid = string.IsNullOrEmpty(resource.DateInvalid) ? (DateTime?)null : DateTime.Parse(resource.DateInvalid),
                Duty = resource.Duty,
                EnteredBy = resource.Links.FirstOrDefault(a => a.Rel == "entered-by")?.Href.ParseId()
            };
        }

        protected override void UpdateFromResource(Tariff entity, TariffResource updateResource)
        {
            entity.Description = updateResource.Description;
            entity.DateInvalid = string.IsNullOrEmpty(updateResource.DateInvalid) ? (DateTime?)null : DateTime.Parse(updateResource.DateInvalid);
            entity.Duty = updateResource.Duty;
            entity.USTariffCode = updateResource.USTariffCode;
            entity.ChangedBy = updateResource.Links.FirstOrDefault(a => a.Rel == "changed-by")?.Href.ParseId();
        }

        protected override Expression<Func<Tariff, bool>> SearchExpression(string searchTerm)
        {
            return t => t.TariffCode.Contains(searchTerm) || t.Description.ToLower().Contains(searchTerm.ToLower());
        }
    }
}
