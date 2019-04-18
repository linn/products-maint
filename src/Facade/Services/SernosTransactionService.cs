namespace Linn.Products.Facade.Services
{
    using System;
    using System.Linq.Expressions;

    using Linn.Common.Facade;
    using Linn.Common.Persistence;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    public class SernosTransactionService : FacadeService<SernosTransaction, string, SernosTransactionResource, SernosTransactionResource>
    {
        public SernosTransactionService(IRepository<SernosTransaction, string> repository, ITransactionManager transactionManager)
            : base(repository, transactionManager)
        {
        }

        protected override SernosTransaction CreateFromResource(SernosTransactionResource resource)
        {
            throw new NotImplementedException();
        }

        protected override void UpdateFromResource(SernosTransaction entity, SernosTransactionResource updateResource)
        {
            throw new NotImplementedException();
        }

        protected override Expression<Func<SernosTransaction, bool>> SearchExpression(string searchTerm)
        {
            throw new NotImplementedException();
        }
    }
}
