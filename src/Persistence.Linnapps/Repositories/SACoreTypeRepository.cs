namespace Linn.Products.Persistence.Linnapps.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using Linn.Products.Domain.Linnapps;

    public class SACoreTypeRepository : IRepository<SaCoreType, int>
    {
        private List<SaCoreType> sACoreTypes = new List<SaCoreType>();

        public SaCoreType FindById(int key)
        {
            return this.sACoreTypes.SingleOrDefault(c => c.CoreType == key);
        }

        public IQueryable<SaCoreType> FindAll()
        {
            return this.sACoreTypes.AsQueryable();
        }

        public void Add(SaCoreType entity)
        {
            this.sACoreTypes.Add(entity);
        }

        public void Remove(SaCoreType entity)
        {
            throw new NotImplementedException();
        }

        public SaCoreType FindBy(Expression<Func<SaCoreType, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IQueryable<SaCoreType> FilterBy(Expression<Func<SaCoreType, bool>> expression)
        {
            throw new NotImplementedException();
        }
    }
}
