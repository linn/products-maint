namespace Linn.Products.Domain.Repositories
{
    using System.Collections.Generic;

    public interface ICartonRepository
    {
        IEnumerable<Carton> GetCartons();
    }
}
