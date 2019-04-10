namespace Linn.Products.Persistence.Linnapps.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using Linn.Common.Persistence;
    using Linn.Products.Domain.Linnapps.Products;

    using Microsoft.EntityFrameworkCore;

    public class SalesArticleRepository : IRepository<SalesArticle, string>
    {
        private readonly ServiceDbContext serviceDbContext;

        public SalesArticleRepository(ServiceDbContext serviceDbContext)
        {
            this.serviceDbContext = serviceDbContext;
        }

        public SalesArticle FindById(string key)
        {
            return this.serviceDbContext.SalesArticles
                .Where(b => b.ArticleNumber == key)
                .Include(a => a.SaCoreType)
                .Include(a => a.HoldStories)
                .ToList().First();
        }

        public IQueryable<SalesArticle> FindAll()
        {
            return this.serviceDbContext.SalesArticles;
        }

        public void Add(SalesArticle entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(SalesArticle entity)
        {
            throw new NotImplementedException();
        }

        public SalesArticle FindBy(Expression<Func<SalesArticle, bool>> expression)
        {
            return this.serviceDbContext.SalesArticles.Where(expression).ToList().FirstOrDefault();
        }

        public IQueryable<SalesArticle> FilterBy(Expression<Func<SalesArticle, bool>> expression)
        {
            return this.serviceDbContext.SalesArticles.Where(expression).Include(a => a.SaCoreType);
        }
    }
}