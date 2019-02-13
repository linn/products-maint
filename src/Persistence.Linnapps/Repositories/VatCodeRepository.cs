namespace Linn.Products.Persistence.Linnapps.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using Linn.Common.Persistence;
    using Linn.Products.Domain.Linnapps;

    public class VatCodeRepository : IRepository<VatCode, string>
    {
        private readonly ServiceDbContext serviceDbContext;

        public VatCodeRepository(ServiceDbContext serviceDbContext)
        {
            this.serviceDbContext = serviceDbContext;
        }

        public VatCode FindById(string key)
        {
            return this.serviceDbContext.VatCodes.Where(a => a.Code == key).ToList().First();
        }

        public IQueryable<VatCode> FindAll()
        {
            return this.serviceDbContext.VatCodes;
        }

        public void Add(VatCode vatCode)
        {
            this.serviceDbContext.VatCodes.Add(vatCode);
            this.serviceDbContext.SaveChanges();
        }

        public void Remove(VatCode entity)
        {
            throw new NotImplementedException();
        }

        public VatCode FindBy(Expression<Func<VatCode, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IQueryable<VatCode> FilterBy(Expression<Func<VatCode, bool>> expression)
        {
            throw new NotImplementedException();
        }
    }
}