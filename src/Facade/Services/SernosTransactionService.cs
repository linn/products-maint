namespace Linn.Products.Facade.Services
{
    using System;
    using System.Linq.Expressions;

    using Linn.Common.Facade;
    using Linn.Common.Persistence;
    using Linn.Products.Domain.Linnapps.SernosTransactions;
    using Linn.Products.Resources;

    public class SernosTransactionService : FacadeService<SernosTrans, string, SernosTransactionResource, SernosTransactionResource>
    {
        public SernosTransactionService(IRepository<SernosTrans, string> repository, ITransactionManager transactionManager)
            : base(repository, transactionManager)
        {
        }

        protected override SernosTrans CreateFromResource(SernosTransactionResource resource)
        {
            throw new NotImplementedException();
        }

        protected override void UpdateFromResource(SernosTrans sernosConfig, SernosTransactionResource updateResource)
        {
            sernosConfig.TransDescription = updateResource.TransDescription;
            sernosConfig.ManualPost = updateResource.ManualPost;
        }

        protected override Expression<Func<SernosTrans, bool>> SearchExpression(string searchTerm)
        {
            return a => a.TransCode.ToLower().Contains(searchTerm.ToLower())
                        || a.TransDescription.ToLower().Contains(searchTerm.ToLower());
        }
    }
}
