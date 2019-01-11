namespace Linn.Products.Service.Modules
{
    using System.Collections.Generic;

    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Domain.Linnapps.RemoteServices;
    using Linn.Products.Resources;
    using Linn.Products.Service.Models;

    using Nancy;
    using Nancy.ModelBinding;
    using Nancy.Security;

    public sealed class SalesArticleModule : NancyModule
    {
        private readonly ISalesArticleService salesArticleService;

        public SalesArticleModule(ISalesArticleService salesArticleService)
        {
            this.salesArticleService = salesArticleService;

            this.Get("/products/maint/sales-articles", _ => this.GetSalesArticles());
        }

        private object GetSalesArticles()
        {
            this.RequiresAuthentication();
            var resource = this.Bind<SalesArticleRequestResource>();
            if (!string.IsNullOrEmpty(resource.ArticleNumber))
            {
                return this.Negotiate
                    .WithModel(new SuccessResult<SalesArticle>(this.salesArticleService.GetSalesArticle(resource.ArticleNumber)))
                    .WithMediaRangeModel("text/html", ApplicationSettings.Get)
                    .WithView("Index");
            }

            return this.Negotiate
                .WithModel(new SuccessResult<IEnumerable<SalesArticle>>(this.salesArticleService.Search(resource.SearchTerm)))
                .WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }
    }
}