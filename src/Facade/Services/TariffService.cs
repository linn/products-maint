namespace Linn.Products.Facade.Services
{
    using System.Collections.Generic;
    using Common.Facade;
    using Domain.Linnapps.Products;
    using Domain.Repositories;

    public class TariffService : ITariffService
    {
        private readonly ITariffRepository tariffRepository;

        public TariffService(ITariffRepository tariffRepository)
        {
            this.tariffRepository = tariffRepository;
        }

        public IResult<IEnumerable<Tariff>> GetTariffs(string searchTerm)
        {
            var tariffs = this.tariffRepository.SearchTariffs(searchTerm);
            return new SuccessResult<IEnumerable<Tariff>>(tariffs);
        }
    }
}