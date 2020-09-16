namespace Linn.Products.Domain.Services
{
    using Linn.Products.Domain.Linnapps;

    public interface ITariffNumberReallocationService
    {
        TariffsReallocator Reallocate(int oldTariffId, int newTariffId);
    }
}
