namespace Linn.Products.Facade.Services
{
    using System;
    using System.Linq.Expressions;

    using Linn.Common.Facade;
    using Linn.Common.Persistence;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Resources;

    public class RootProductService : FacadeService<RootProduct, string, RootProductResource, RootProductResource>
    {
        private readonly IRepository<RootProduct, string> rootProductRepository;

        public RootProductService(IRepository<RootProduct, string> repository, ITransactionManager transactionManager)
            : base(repository, transactionManager)
        {
            this.rootProductRepository = repository;
        }

        protected override RootProduct CreateFromResource(RootProductResource resource)
        {
            throw new NotImplementedException();
        }

        protected override void UpdateFromResource(RootProduct entity, RootProductResource updateResource)
        {
            throw new NotImplementedException();
        }

        protected override Expression<Func<RootProduct, bool>> SearchExpression(string searchTerm)
        {
            return t => t.Name.Contains(searchTerm) || t.Description.ToLower().Contains(searchTerm.ToLower());
        }
    }
}
