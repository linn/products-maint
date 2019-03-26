using System;
using Linn.Common.Facade;
using Linn.Common.Persistence;
using Linn.Products.Domain.Linnapps.Products;
using Linn.Products.Resources;

namespace Linn.Products.Facade.Services
{
    public class TariffService : FacadeService<Tariff, int, TariffResource, TariffResource>
    {
        public TariffService(IRepository<Tariff, int> repository, ITransactionManager transactionManager) : base(repository, transactionManager)
        {
        }

        protected override Tariff CreateFromResource(TariffResource resource)
        {
            var tariff = new Tariff
            {
                TariffCode = resource.TariffCode,
                Description = resource.Description,
                USTariffCode = resource.USTariffCode,
                DateInvalid = string.IsNullOrEmpty(resource.DateInvalid) ? (DateTime?) null : DateTime.Parse(resource.DateInvalid),
                Duty = resource.Duty
            };

            return tariff;
        }

        protected override void UpdateFromResource(Tariff entity, TariffResource updateResource)
        {
            entity.Description = updateResource.Description;
            entity.DateInvalid = string.IsNullOrEmpty(updateResource.DateInvalid) ? (DateTime?) null : DateTime.Parse(updateResource.DateInvalid);
            entity.Duty = updateResource.Duty;
            entity.USTariffCode = updateResource.USTariffCode;
        }
    }
}
