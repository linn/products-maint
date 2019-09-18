namespace Linn.Products.Domain.Linnapps.RemoteServices
{
    using System.Collections.Generic;

    using Linn.Products.Domain.Linnapps.Models;

    public interface IProductionTriggerLevelsService
    {
        IEnumerable<ProductionTriggerLevel> GetAll();
    }
}
