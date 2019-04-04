﻿namespace Linn.Products.Facade.Services
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection.Metadata.Ecma335;

    using Linn.Common.Facade;
    using Linn.Common.Persistence;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Domain.Linnapps.RemoteServices;
    using Linn.Products.Facade.Extensions;
    using Linn.Products.Persistence.Linnapps.Repositories;
    using Linn.Products.Resources;

    public class SaHoldStoryFacadeService : FacadeService<SaHoldStory, int, SaHoldStoryResource, SaHoldStoryResource>
    {
        private readonly IRepository<SalesArticle, string> salesArticleRepository;

        private IRepository<Employee, int> employeeRepository;

        public SaHoldStoryFacadeService(
            IRepository<SaHoldStory, int> repo,
            ITransactionManager transactionManager,
            IRepository<SalesArticle, string> salesArticleRepository,
            IRepository<Employee, int> employeeRepository)
            : base(repo, transactionManager)
        {
            this.salesArticleRepository = salesArticleRepository;
            this.employeeRepository = employeeRepository;
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
                                    RootProduct = resource.RootProduct,
                                    DateFinished = null,
                                    ReasonFinished = null,
                                    AnticipatedEndDate = string.IsNullOrEmpty(resource.AnticipatedEndDate) ? (DateTime?)null : DateTime.Parse(resource.AnticipatedEndDate),

            };
            return holdStory;
        }

        protected override void UpdateFromResource(SaHoldStory entity, SaHoldStoryResource updateResource)
        {
            throw new System.NotImplementedException();
        }

        protected override Expression<Func<SaHoldStory, bool>> SearchExpression(string searchTerm)
        {
            throw new NotImplementedException();
        }
    }
}
