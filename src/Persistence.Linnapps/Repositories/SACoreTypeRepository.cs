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

        public SaCoreTypeRepository()
        {
            this.saCoreTypes = this.MakeSaCoreTypes();
        }

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

        private List<SaCoreType> MakeSaCoreTypes()
        {
            return new List<SaCoreType>
                       {
                           new SaCoreType(1, "CORE PRODUCT (SUGGESTED)", DateTime.Parse("2007/09/07"), null, 1000, null),

                           new SaCoreType(2, "BUILT TO ORDER", null, null, 20, 0),

                           new SaCoreType(1, "SALES ADVISED PRODUCT", DateTime.Parse("2007/09/07"), null, 30, 0),

                           new SaCoreType(4, "CORE PRODUCT",null, null, 5, 10),
                           
                           new SaCoreType(5, "END OF LIFE", null, null, 40, null),
                           
                           new SaCoreType(6, "SPECIAL ORDER PRODUCT", null, 15, 50, null),
                       };
        }
    }
}