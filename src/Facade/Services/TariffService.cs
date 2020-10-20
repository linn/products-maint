namespace Linn.Products.Facade.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Linn.Common.Facade;
    using Linn.Common.Persistence;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Domain.Repositories;
    using Linn.Products.Facade.Extensions;
    using Linn.Products.Resources;

    public class TariffService : FacadeService<Tariff, int, TariffResource, TariffResource>, ITariffFacadeService
    {
        private readonly ITransactionManager transactionManager;

        private readonly ISalesPartRepository salesPartRepository;

        public TariffService(
            IRepository<Tariff, int> repository,
            ITransactionManager transactionManager,
            ISalesPartRepository salesPartRepository)
            : base(repository, transactionManager)
        {
            this.transactionManager = transactionManager;
            this.salesPartRepository = salesPartRepository;
        }

        public IResult<ResponseModel<TariffsReallocator>> Reallocate(int oldTariffId, int newTariffId, IEnumerable<string> privileges)
        {
            var reallocated = new TariffsReallocator();
            try
            {
                this.salesPartRepository.ReallocateSalesParts(oldTariffId, newTariffId);
            }
            catch (Exception ex)
            {
                return new BadRequestResult<ResponseModel<TariffsReallocator>>($"Error updating sales articles from tariff {oldTariffId} to {newTariffId} - ${ex.Message})");
            }
            this.transactionManager.Commit();

            return new SuccessResult<ResponseModel<TariffsReallocator>>(new ResponseModel<TariffsReallocator>(
                reallocated, privileges));
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
