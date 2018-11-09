namespace Linn.Products.Persistence.Linnapps.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using Linn.Products.Domain.Linnapps;

    public class SaCoreTypeRepository : IRepository<SaCoreType, int>
    {
        private readonly List<SaCoreType> saCoreTypes = new List<SaCoreType>();

        public SaCoreType FindById(int key)
        {
            return this.saCoreTypes.SingleOrDefault(c => c.CoreType == key);
        }

        public IQueryable<SaCoreType> FindAll()
        {
            return this.saCoreTypes.AsQueryable();
        }

        public void Add(SaCoreType entity)
        {
            this.saCoreTypes.Add(entity);
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
