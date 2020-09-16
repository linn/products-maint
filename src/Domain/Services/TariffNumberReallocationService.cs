namespace Linn.Products.Domain.Services
{
    using System;
    using System.Linq;
    using Linn.Common.Domain.Exceptions;
    using Linn.Common.Persistence;
    using Linn.Products.Domain.Dispatchers;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Domain.Products;

    public class TariffNumberReallocationService : ITariffNumberReallocationService
    {
        private readonly IRepository<ProductSalesPart, int> salesPartRepository;

        private readonly ISalesPartUpdatedDispatcher dispatcher;

        public TariffNumberReallocationService(IRepository<ProductSalesPart, int> salesPartRepository, ISalesPartUpdatedDispatcher dispatcher)
        {
            this.salesPartRepository = salesPartRepository;
            this.dispatcher = dispatcher;
        }

        TariffsReallocator ITariffNumberReallocationService.Reallocate(int oldTariffId, int newTariffId)
        {
            if (oldTariffId == 0 || newTariffId == 0)
            {
                throw new DomainException("Tariff Id cannot be 0");
            }

            var partsForReallocation =
                this.salesPartRepository.FindAll().Where(x => x.Tariff.Id == oldTariffId);

            var count = partsForReallocation.Count();

            try
            {
                foreach (var salesPart in partsForReallocation)
                {
                    salesPart.Tariff.Id = newTariffId;
                    this.dispatcher.DispatchSalesPartUpdated(salesPart);

                }
            }
            catch (Exception ex)
            {
                throw new DomainException(
                    "An error has occurred when trying to reallocate the relevant sales parts");
            }

            return new TariffsReallocator { OldTariffId = oldTariffId, NewTariffId = newTariffId, Count = count };
        }
    }
}
