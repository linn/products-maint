﻿namespace Linn.Products.Facade.Services
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

    public class SaHoldStoryFacadeService : FacadeService<SaHoldStory, int, SaHoldStoryResource, SaHoldStoryResource>
    {
        private readonly IRepository<SalesArticle, string> salesArticleRepository;
        private readonly IRepository<RootProduct, string> rootProductRepository;

        private readonly IRepository<Employee, int> employeeRepository;

        public SaHoldStoryFacadeService(
            IRepository<SaHoldStory, int> saHoldStoryRepository,
            ITransactionManager transactionManager,
            IRepository<SalesArticle, string> salesArticleRepository,
            IRepository<RootProduct, string> rootProductRepository,
            IRepository<Employee, int> employeeRepository)
            : base(saHoldStoryRepository, transactionManager)
        {
            this.salesArticleRepository = salesArticleRepository;
            this.employeeRepository = employeeRepository;
            this.rootProductRepository = rootProductRepository;
        }

        protected override SaHoldStory CreateFromResource(SaHoldStoryResource resource)
        {
            var holdStory = new SaHoldStory
                                {
                                    ArticleNumber = resource.SalesArticle,
                                    SalesArticle = this.salesArticleRepository.FindById(resource.SalesArticle),
                                    DateStarted = DateTime.Parse(resource.DateStarted),
                                    PutOnHoldByEmployee = this.employeeRepository.FindById((int)resource.Links.FirstOrDefault(a => a.Rel == "put-on-hold-by")?.Href.ParseId()),
                                    ReasonStarted = resource.ReasonStarted,
                                    RootProduct = this.rootProductRepository.FindById(resource.RootProduct),
                                    RootProductName = resource.RootProduct,
                                    DateFinished = null,
                                    ReasonFinished = null,
                                    AnticipatedEndDate = string.IsNullOrEmpty(resource.AnticipatedEndDate) ? (DateTime?)null : DateTime.Parse(resource.AnticipatedEndDate),
            };
            return holdStory;
        }

        protected override void UpdateFromResource(SaHoldStory entity, SaHoldStoryResource updateResource)
        {
            var employeeUri = updateResource.Links.FirstOrDefault(l => l.Rel == "taken-off-hold-by")?.Href;
            entity.DateFinished = DateTime.Parse(updateResource.DateFinished);
            entity.ReasonFinished = updateResource.ReasonFinished;
            entity.TakenOffHoldByEmployee = this.employeeRepository.FindById((int)employeeUri.ParseId());
        }

        protected override Expression<Func<SaHoldStory, bool>> SearchExpression(string searchTerm)
        {
            throw new NotImplementedException();
        }
    }
}
