namespace Linn.Products.Domain.Linnapps.Repositories
{
    using System.Collections.Generic;

    public interface ISernosConfigRepository
    {
        SernosConfig Get(string name);

        IEnumerable<SernosConfig> GetAll();

        void Add(SernosConfig sernosConfig);
    }
}
