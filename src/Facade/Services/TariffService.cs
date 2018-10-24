namespace Linn.Products.Facade.Services
{
    using System.Collections.Generic;
    using Common.Facade;
    using Domain.Linnapps.Products;
    using Domain.Repositories;
    using Resources;

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

        public IResult<Tariff> GetTariff(int id)
        {
            var tariff = this.tariffRepository.GetTariffById(id);

            if (tariff == null)
            {
                return new NotFoundResult<Tariff>($"no tariff with id {id}");
            }

            return new SuccessResult<Tariff>(tariff);
        }

        public IResult<Tariff> AddTariff(TariffResource resource)
        {
            Tariff tariff;

            tariff = new Tariff()
            {
                Description = resource.Description,
                TariffCode = resource.TariffCode,
                USTariffCode = resource.USTariffCode,
                DateInvalid = resource.DateInvalid,
                Duty = resource.Duty
            };

            this.tariffRepository.Add(tariff);

            return new CreatedResult<Tariff>(tariff);
        }

        public IResult<Tariff> UpdateTariff(int id, TariffResource resource)
        {
            throw new System.NotImplementedException();
        }
    }
}