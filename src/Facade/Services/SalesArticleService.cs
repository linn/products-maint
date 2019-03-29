namespace Linn.Products.Facade.Services
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using Linn.Common.Facade;
    using Linn.Common.Persistence;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Facade.Extensions;
    using Linn.Products.Resources;

    public class SalesArticleService : FacadeService<SalesArticle, string, SalesArticleResource, SalesArticleResource>
    {
        private readonly IRepository<SaCoreType, int> coreTypeRepository;

        public SalesArticleService(
            IRepository<SalesArticle, string> repository,
            IRepository<SaCoreType, int> coreTypeRepository,
            ITransactionManager transactionManager)
            : base(repository, transactionManager)
        {
            this.coreTypeRepository = coreTypeRepository;
        }

        protected override SalesArticle CreateFromResource(SalesArticleResource resource)
        {
            throw new NotImplementedException();
        }

        protected override void UpdateFromResource(SalesArticle salesArticle, SalesArticleResource updateResource)
        {
            var coreTypeHref = updateResource.Links?.FirstOrDefault(a => a.Rel == "sa-core-type")?.Href;
            var coreType = string.IsNullOrEmpty(coreTypeHref)
                               ? null
                               : this.coreTypeRepository.FindById(coreTypeHref.ParseId());
            salesArticle.Update(
                updateResource.ForecastType,
                string.IsNullOrEmpty(updateResource.ForecastFromDate) ? (DateTime?)null : DateTime.Parse(updateResource.ForecastFromDate),
                string.IsNullOrEmpty(updateResource.ForecastToDate) ? (DateTime?)null : DateTime.Parse(updateResource.ForecastToDate),
                updateResource.PercentageOfRootProductSales,
                coreType);
        }

        protected override Expression<Func<SalesArticle, bool>> SearchExpression(string searchTerm)
        {
            throw new NotImplementedException();
        }
    }
}
