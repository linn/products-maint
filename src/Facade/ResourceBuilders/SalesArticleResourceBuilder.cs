﻿namespace Linn.Products.Facade.ResourceBuilders
{
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
                           Links = this.BuildLinks(salesArticle).ToArray()
                       };
        }

        object IResourceBuilder<SalesArticle>.Build(SalesArticle salesArticle) => this.Build(salesArticle);

        public string GetLocation(SalesArticle salesArticle)
        {
            return $"/products/maint/sales-articles?articleNumber={salesArticle.ArticleNumber}";
        }

        private IEnumerable<LinkResource> BuildLinks(SalesArticle salesArticle)
        {
            yield return new LinkResource
                             {
                                 Rel = "self",
                                 Href = this.GetLocation(salesArticle)
                             };
        }
    }
}