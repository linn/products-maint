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
        private readonly IFacadeService<SalesArticle, string, SalesArticleResource> salesArticleForecastService;

        private readonly ISalesArticleService salesArticleProxyService;

        public SalesArticleModule(
            IFacadeService<SalesArticle, string, SalesArticleResource> salesArticleForecastService,
            ISalesArticleService salesArticleProxyService)
        {
            this.salesArticleForecastService = salesArticleForecastService;
            this.salesArticleProxyService = salesArticleProxyService;

            this.Get("/products/maint/sales-articles", _ => this.GetSalesArticles());
            this.Get("/products/maint/sales-articles/{id*}", parameters => this.GetSalesArticle(parameters.id));
            this.Put("/products/maint/sales-articles/{id*}", parameters => this.UpdateSalesArticle(parameters.id));
        }

        private object GetSalesArticle(string id)
        {
            return this.Negotiate
                .WithModel(this.salesArticleForecastService.GetById(id))
                .WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }

        private object UpdateSalesArticle(string id)
        {
            this.RequiresAuthentication();
            var resource = this.Bind<SalesArticleResource>();
            var result = this.salesArticleForecastService.Update(id, resource);

            return this.Negotiate
                .WithModel(result)
                .WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }

        private object GetSalesArticles()
        {
            this.RequiresAuthentication();
            var resource = this.Bind<SalesArticleRequestResource>();
            if (!string.IsNullOrEmpty(resource.ArticleNumber))
            {
                return this.Negotiate
                    .WithModel(this.salesArticleForecastService.GetById(resource.ArticleNumber))
                    .WithMediaRangeModel("text/html", ApplicationSettings.Get)
                    .WithView("Index");
            }

            return this.Negotiate
                .WithModel(new SuccessResult<IEnumerable<SalesArticle>>(this.salesArticleProxyService.Search(resource.SearchTerm)))
                .WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }
    }
}