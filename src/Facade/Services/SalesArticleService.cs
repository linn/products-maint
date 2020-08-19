namespace Linn.Products.Facade.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Security.Cryptography.X509Certificates;

    using Linn.Common.Facade;
    using Linn.Common.Persistence;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Facade.Extensions;
    using Linn.Products.Resources;

    public class SalesArticleService : FacadeService<SalesArticle, string, SalesArticleResource, SalesArticleResource>, ISalesArticleFacadeService
    {
        private readonly IRepository<SaCoreType, int> coreTypeRepository;
        private readonly IRepository<SalesArticle, string> salesArticleRepository;

        private readonly ITransactionManager transactionManager;

        public SalesArticleService(
            IRepository<SalesArticle, string> repository,
            IRepository<SaCoreType, int> coreTypeRepository,
            ITransactionManager transactionManager)
            : base(repository, transactionManager)
        {
            this.coreTypeRepository = coreTypeRepository;
            this.salesArticleRepository = repository;
            this.transactionManager = transactionManager;
        }

        protected override SalesArticle CreateFromResource(SalesArticleResource resource)
        {
            throw new NotImplementedException();
        }

        protected override void UpdateFromResource(SalesArticle salesArticleResponseModel, SalesArticleResource updateResource)
        {
            var coreTypeHref = updateResource.Links?.FirstOrDefault(a => a.Rel == "sa-core-type")?.Href;
            var coreType = string.IsNullOrEmpty(coreTypeHref)
                               ? null
                               : this.coreTypeRepository.FindById(coreTypeHref.ParseId());
            salesArticleResponseModel.Update(
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

        public IResult<ResponseModel<SalesArticlesReallocator>> Reallocate(int oldTariffId, int newTariffId, IEnumerable<string> privileges)
        {
            
            var articlesForReallocation = this.salesArticleRepository.FindAll().Where(x=>x.TariffId == oldTariffId);
            foreach (var salesArticle in articlesForReallocation)
            {
                salesArticle.TariffId = newTariffId;
            }
            this.salesArticleRepository.g

            this.transactionManager.Commit();
            return new SuccessResult<ResponseModel<SalesArticlesReallocator>>( new ResponseModel<SalesArticlesReallocator>( 
                new SalesArticlesReallocator{OldTariffId = oldTariffId, NewTariffId = newTariffId}, privileges));
        }
    }
}
