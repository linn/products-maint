namespace Linn.Products.Domain.Linnapps.Services
{
    public interface ISalesArticleReallocationService
    {
        SalesArticlesReallocator Reallocate(int oldTariffId, int newTariffId);
    }
}
