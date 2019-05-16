namespace Linn.Products.Facade.Services
{
    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps.Models;

    public interface ISalesArticleSerialNumberFacadeService
    {
        IResult<SalesArticleSerialNumberDetails> GetSerialNumberDetails(string articleNumber);
    }
}