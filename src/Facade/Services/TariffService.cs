namespace Linn.Products.Facade.Services
{
    using System;
    using System.Collections.Generic;
    using Common.Persistence;
    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Domain.Linnapps.Repositories;
    using Linn.Products.Resources;
    using Linn.Products.Persistence.Linnapps;

    public class TariffService : ITariffService
    {
        private readonly ITariffRepository tariffRepository;
        private readonly ITransactionManager transactionManager;

        public TariffService(ITariffRepository tariffRepository, ITransactionManager transactionManager)
        {
            this.tariffRepository = tariffRepository;
            this.transactionManager = transactionManager;
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
            var tariff = new Tariff
                             {
                                 Description = resource.Description,
                                 TariffCode = resource.TariffCode,
                                 USTariffCode = resource.USTariffCode,
                                 DateInvalid = string.IsNullOrEmpty(resource.DateInvalid) ? null : (DateTime?)Convert.ToDateTime(resource.DateInvalid),
                                 Duty = resource.Duty
                             };

            this.tariffRepository.Add(tariff);
            this.transactionManager.Commit();

            return new CreatedResult<Tariff>(tariff);
        }

        public IResult<Tariff> UpdateTariff(int id, TariffResource resource)
        {
            var tariff = this.tariffRepository.GetTariffById(id);

            if (tariff == null)
            {
                return new NotFoundResult<Tariff>($"No tariff with id {id}");
            }

            tariff.TariffCode = resource.TariffCode;
            tariff.USTariffCode = resource.USTariffCode;
            tariff.Description = resource.Description;
            tariff.DateInvalid = string.IsNullOrEmpty(resource.DateInvalid) ? null : (DateTime?)Convert.ToDateTime(resource.DateInvalid);
            tariff.Duty = resource.Duty;

            this.transactionManager.Commit();

            return new SuccessResult<Tariff>(tariff);
        }
    }
}