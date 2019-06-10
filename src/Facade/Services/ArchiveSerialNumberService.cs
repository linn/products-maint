namespace Linn.Products.Facade.Services
{
    using System;
    using System.Linq.Expressions;

    using Linn.Common.Facade;
    using Linn.Common.Persistence;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    public class ArchiveSerialNumberService : FacadeService<ArchiveSerialNumber, int, ArchiveSerialNumberResource, ArchiveSerialNumberResource>
    {
        public ArchiveSerialNumberService(IRepository<ArchiveSerialNumber, int> repository, ITransactionManager transactionManager)
            : base(repository, transactionManager)
        {
        }

        protected override ArchiveSerialNumber CreateFromResource(ArchiveSerialNumberResource resource)
        {
            throw new NotImplementedException();
        }

        protected override void UpdateFromResource(ArchiveSerialNumber entity, ArchiveSerialNumberResource updateResource)
        {
            throw new NotImplementedException();
        }

        protected override Expression<Func<ArchiveSerialNumber, bool>> SearchExpression(string searchTerm)
        {
            return s => s.SernosNumber.ToString().Equals(searchTerm);
        }
    }
}
