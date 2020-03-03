namespace Linn.Products.Persistence.Linnapps.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using Linn.Common.Persistence;
    using Linn.Products.Domain.Linnapps;

    public class SalesAnalysisRepository : IQueryRepository<SalesAnalysis>
    {
        private readonly ServiceDbContext serviceDbContext;

        public SalesAnalysisRepository(ServiceDbContext serviceDbContext)
        {
            this.serviceDbContext = serviceDbContext;
        }

        public SalesAnalysis FindBy(Expression<Func<SalesAnalysis, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IQueryable<SalesAnalysis> FilterBy(Expression<Func<SalesAnalysis, bool>> expression)
        {
            return this.serviceDbContext.SalesAnalyses.Where(expression);
        }

        public IQueryable<SalesAnalysis> FindAll()
        {
            throw new NotImplementedException();
        }
    }
}