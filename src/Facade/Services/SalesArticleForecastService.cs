namespace Linn.Products.Facade.Services
{
    using System;

    using Linn.Common.Facade;
    using Linn.Common.Persistence;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Resources;

    public class SalesArticleForecastService : FacadeService<SalesArticle, string, SalesArticleResource>
    {
        public SalesArticleForecastService(IRepository<SalesArticle, string> repository) : base(repository)
        {
        }

        protected override SalesArticle CreateFromResource(SalesArticleResource resource)
        {
            throw new NotImplementedException();
        }

        protected override void UpdateFromResource(SalesArticle salesArticle, SalesArticleResource updateResource)
        {
            salesArticle.UpdateForecastInformation(
                updateResource.ForecastType,
                string.IsNullOrEmpty(updateResource.ForecastFromDate) ? (DateTime?)null : DateTime.Parse(updateResource.ForecastFromDate),
                string.IsNullOrEmpty(updateResource.ForecastToDate) ? (DateTime?)null : DateTime.Parse(updateResource.ForecastToDate),
                updateResource.PercentageOfRootProductSales);
        }
    }
}
