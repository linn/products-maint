namespace Linn.Products.Facade.Services
{
    using System.Collections.Generic;
    using Common.Facade;
    using Domain.Linnapps.Products;

    public interface ITariffService
    {
        IResult<IEnumerable<Tariff>> GetTariffs();
    }
}