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