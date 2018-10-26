namespace Linn.Products.Facade.Services
{
    using System.Collections.Generic;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;

    public interface IFacadeService<T, in TResource, in Tkey>
    {
        IResult<T> Get(Tkey id);

        IResult<IEnumerable<T>> GetAll();

        IResult<T> Add(TResource resource);

        IResult<T> Update(Tkey id, TResource resource);
    }

    public class SernosConfigService : IFacadeService<SernosConfig, SernosConfig, string>
    {
        public IResult<SernosConfig> Get(string id)
        {
            throw new System.NotImplementedException();
        }

        public IResult<IEnumerable<SernosConfig>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public IResult<SernosConfig> Add(SernosConfig resource)
        {
            throw new System.NotImplementedException();
        }

        public IResult<SernosConfig> Update(string id, SernosConfig resource)
        {
            throw new System.NotImplementedException();
        }
    }
}
