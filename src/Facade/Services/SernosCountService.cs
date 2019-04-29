namespace Linn.Products.Facade.Services
{
    using System;
    using System.Linq.Expressions;

    using Linn.Common.Facade;
    using Linn.Common.Persistence;
    using Linn.Products.Domain.Linnapps.SernosTransactions;
    using Linn.Products.Resources;

    public class SernosCountService : FacadeService<SernosCount, string, SernosCountResource, SernosCountResource>
    {
        public SernosCountService(IRepository<SernosCount, string> repository, ITransactionManager transactionManager)
            : base(repository, transactionManager)
        {
        }

        protected override SernosCount CreateFromResource(SernosCountResource resource)
        {
            throw new NotImplementedException();
        }

        protected override void UpdateFromResource(SernosCount sernosCount, SernosCountResource updateResource)
        {
            throw new NotImplementedException();
        }

        protected override Expression<Func<SernosCount, bool>> SearchExpression(string searchTerm)
        {
            throw new NotImplementedException();
        }
    }
}