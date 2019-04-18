namespace Linn.Products.Facade.Services
{
    using System;
    using System.Linq.Expressions;

    using Linn.Common.Facade;
    using Linn.Common.Persistence;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;

    public class SernosTransService : FacadeService<SernosTrans, string, SernosTransResource, SernosTransResource>
    {
        public SernosTransService(IRepository<SernosTrans, string> repository, ITransactionManager transactionManager)
            : base(repository, transactionManager)
        {
        }

        protected override SernosTrans CreateFromResource(SernosTransResource resource)
        {
            throw new NotImplementedException();
        }

        protected override void UpdateFromResource(SernosTrans entity, SernosTransResource updateResource)
        {
            throw new NotImplementedException();
        }

        protected override Expression<Func<SernosTrans, bool>> SearchExpression(string searchTerm)
        {
            throw new NotImplementedException();
        }
    }
}
