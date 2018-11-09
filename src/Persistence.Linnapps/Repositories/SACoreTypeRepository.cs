namespace Linn.Products.Persistence.Linnapps.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using Linn.Products.Domain.Linnapps;

    public class SACoreTypeRepository : IRepository<SACoreType, int>
    {
        private List<SACoreType> sACoreTypes = new List<SACoreType>();

        public SACoreType FindById(int key)
        {
            return this.sACoreTypes.SingleOrDefault(c => c.CoreType == key);
        }

        public IQueryable<SACoreType> FindAll()
        {
            return this.sACoreTypes.AsQueryable();
        }

        public void Add(SACoreType entity)
        {
            this.sACoreTypes.Add(entity);
        }

        public void Remove(SACoreType entity)
        {
            throw new NotImplementedException();
        }

        public SACoreType FindBy(Expression<Func<SACoreType, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IQueryable<SACoreType> FilterBy(Expression<Func<SACoreType, bool>> expression)
        {
            throw new NotImplementedException();
        }
    }
}
