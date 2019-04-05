namespace Linn.Products.Facade.ResourceBuilders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Linn.Common.Facade;
    using Linn.Common.Resources;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Resources;

    public class SalesArticleResourceBuilder : IResourceBuilder<SalesArticle>
    {
        public SalesArticleResource Build(SalesArticle salesArticle)
        {
            return new SalesArticleResource
                       {
                           Id = salesArticle.ArticleNumber,
                           ArticleNumber = salesArticle.ArticleNumber,
                           ArticleType = salesArticle.ArticleType,
                           Description  = salesArticle.InvoiceDescription,
                           CartonType = salesArticle.CartonType,
                           ForecastType = salesArticle.ForecastType,
                           ForecastFromDate = salesArticle.ForecastFromDate?.ToString("o"),
                           ForecastToDate = salesArticle.ForecastToDate?.ToString("o"),
                           PercentageOfRootProductSales = salesArticle.PercentageOfRootProductSales,
                           EanCode = salesArticle.EanCode,
                           SaDiscountFamily = salesArticle.SaDiscountFamily,
                           PhaseInDate = salesArticle.PhaseInDate?.ToString("o"),
                           PhaseOutDate = salesArticle.PhaseOutDate?.ToString("o"),
                           TypeOfSale = salesArticle.TypeOfSale,
                           PackingDescription = salesArticle.PackingDescription,
                           Links = this.BuildLinks(salesArticle).ToArray(),
                           OnHold = this.IsOnHold(salesArticle)
                       };
        }

        object IResourceBuilder<SalesArticle>.Build(SalesArticle salesArticle) => this.Build(salesArticle);

        public string GetLocation(SalesArticle salesArticle)
        {
            return $"/products/maint/sales-articles/{Uri.EscapeDataString(salesArticle.ArticleNumber)}";
        }

        private bool IsOnHold(SalesArticle salesArticle)
        {
           if (salesArticle.HoldStories == null)
            {;
                return false;
            }
            var holdStories = salesArticle.HoldStories;
            foreach (var story in holdStories)
            {
                if (story.DateFinished == null)
                {
                    return true;
                }
            }

            return false;
        }

        private IEnumerable<LinkResource> BuildLinks(SalesArticle salesArticle)
        {
            yield return new LinkResource
                             {
                                 Rel = "self",
                                 Href = this.GetLocation(salesArticle)
                             };

            yield return new LinkResource
                             {
                                Rel = "hold-stories",
                                Href = $"/products/reports/sa-hold-stories-for-sales-article/{Uri.EscapeDataString(salesArticle.ArticleNumber)}"
                             };

            yield return new LinkResource
                             {
                                 Rel = "put-on-hold",
                                 Href = $"/products/maint/put-product-on-hold/{Uri.EscapeDataString(salesArticle.ArticleNumber)}"
                             };

            if (salesArticle.SaCoreType != null)
            {
                yield return new LinkResource
                             {
                                 Rel = "sa-core-type",
                                 Href = $"/products/maint/sa-core-types/{salesArticle.SaCoreType.CoreType}"
                             };
            }
        }
    }
}