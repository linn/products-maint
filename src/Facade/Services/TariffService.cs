namespace Linn.Products.Facade.Services
{
    using System.Collections.Generic;
    using Common.Facade;
    using Domain.Products;

    public class TariffService : ITariffService
    {
        public IResult<IEnumerable<Tariff>> GetTariffs()
        {
            var tariffs = new List<Tariff>();
            tariffs.Add(new Tariff()
            {
                Id = 1,
                TariffCode = "8518 9000 99",
                USTariffCode = "8518.90.3000",
                Description = "Parts and accessories for loudspeakers and amplifiers"
            });
            tariffs.Add(new Tariff()
            {
                Id = 2,
                TariffCode = "8518 2200 90",
                USTariffCode = "8518.22.0000",
                Description = "Multiple loudspeakers mounted in the same enclosure"
            });
            tariffs.Add(new Tariff()
            {
                Id = 3,
                TariffCode = "8523493900",
                Duty = 3.5m,
                Description = "Multiple loudspeakers mounted in the same enclosure"
            });
            return new SuccessResult<IEnumerable<Tariff>>(tariffs);
        }
    }
}