namespace Linn.Products.Facade.ResourceBuilders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Resources;

    public class SalesArticlesResourceBuilder : IResourceBuilder<IEnumerable<SalesArticle>>
    {
        private readonly SalesArticleResourceBuilder salesArticleResourceBuilder = new SalesArticleResourceBuilder();

        public IEnumerable<SalesArticleResource> Build(IEnumerable<SalesArticle> salesArticles)
        {
            return salesArticles.Select(a => this.salesArticleResourceBuilder.Build(a));
        }

        object IResourceBuilder<IEnumerable<SalesArticle>>.Build(IEnumerable<SalesArticle> salesArticles) =>
            this.Build(salesArticles);

        public string GetLocation(IEnumerable<SalesArticle> salesArticles)
        {
            throw new NotImplementedException();
        }
    }
}