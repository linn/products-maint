namespace Linn.Products.Service.Modules
{
    using Linn.Common.Facade;
    using Linn.Products.Domain;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Domain.Linnapps.Products;
    using Linn.Products.Domain.Linnapps.RemoteServices;
    using Linn.Products.Facade.Services;
    using Linn.Products.Resources;
    using Linn.Products.Service.Extensions;
    using Linn.Products.Service.Models;
    using Nancy;
    using Nancy.ModelBinding;
    using Nancy.Security;
    using System.Collections.Generic;
    using System.Linq;

    public sealed class SalesArticleModule : NancyModule
    {
        private readonly ISalesArticleFacadeService salesArticleService;

        private readonly ISalesArticleCompositeDiscountFacadeService salesArticleCompositeDiscountFacadeService;

        private readonly ISalesArticleService salesArticleProxyService;

        private readonly ISalesArticleSerialNumberFacadeService salesArticleSerialNumberFacadeService;

        private readonly IAuthorisationService authorisationService;

        public SalesArticleModule(
            ISalesArticleFacadeService salesArticleService,
            ISalesArticleCompositeDiscountFacadeService salesArticleCompositeDiscountFacadeService,
            ISalesArticleService salesArticleProxyService,
            ISalesArticleSerialNumberFacadeService salesArticleSerialNumberFacadeService,
            IAuthorisationService authorisationService)
        {
            this.salesArticleService = salesArticleService;
            this.salesArticleCompositeDiscountFacadeService = salesArticleCompositeDiscountFacadeService;
            this.salesArticleProxyService = salesArticleProxyService;
            this.salesArticleSerialNumberFacadeService = salesArticleSerialNumberFacadeService;
            this.authorisationService = authorisationService;


            this.Get("/products/maint/sales-articles", _ => this.GetSalesArticles());
            this.Get("/products/maint/sales-articles/{id*}", parameters => this.GetSalesArticle(parameters.id));
            this.Put("/products/maint/sales-articles/{id*}", parameters => this.UpdateSalesArticle(parameters.id));

            this.Get(
                "/products/maint/sales-articles/composite-discounts/{id*}",
                parameters => this.GetSalesArticleCompositeDiscount(parameters.id));
            this.Put(
                "/products/maint/sales-articles/composite-discounts/{id*}",
                parameters => this.UpdateSalesArticleCompositeDiscount(parameters.id));

            this.Get(
                "/products/maint/sales-articles/serial-number-details/{id*}",
                parameters => this.GetSerialNumberDetails(parameters.id));
            this.Post("/products/maint/sales-articles/reallocate", _ => this.ReallocateSalesArticles());
        }

        private object GetSerialNumberDetails(string id)
        {
            var result = this.salesArticleSerialNumberFacadeService.GetSerialNumberDetails(id.ToUpper());

            return this.Negotiate.WithModel(result).WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }

        private object UpdateSalesArticleCompositeDiscount(string id)
        {
            this.RequiresAuthentication();

            return this.Negotiate
                .WithModel(
                    this.salesArticleCompositeDiscountFacadeService.SetCompositeDiscount(
                        id.ToUpper(),
                        this.Bind<SalesArticleCompositeDiscountResource>()))
                .WithMediaRangeModel("text/html", ApplicationSettings.Get).WithView("Index");
        }

        private object GetSalesArticleCompositeDiscount(string id)
        {
            return this.Negotiate
                .WithModel(this.salesArticleCompositeDiscountFacadeService.GetCompositeDiscount(id.ToUpper()))
                .WithMediaRangeModel("text/html", ApplicationSettings.Get).WithView("Index");
        }

        private object GetSalesArticle(string id)
        {
            return this.Negotiate
                .WithModel(
                    this.salesArticleService.GetById(id.ToUpper(), this.Context?.CurrentUser?.GetPrivileges().ToList()))
                .WithMediaRangeModel("text/html", ApplicationSettings.Get).WithView("Index");
        }

        private object UpdateSalesArticle(string id)
        {
            this.RequiresAuthentication();

            return this.Negotiate
                .WithModel(
                    this.salesArticleService.Update(
                        id.ToUpper(),
                        this.Bind<SalesArticleResource>(),
                        this.Context.CurrentUser.GetPrivileges()))
                .WithMediaRangeModel("text/html", ApplicationSettings.Get).WithView("Index");
        }

        private object GetSalesArticles()
        {
            var resource = this.Bind<SalesArticleRequestResource>();
            if (!string.IsNullOrEmpty(resource.ArticleNumber))
            {
                return this.Negotiate
                    .WithModel(
                        this.salesArticleService.GetById(
                            resource.ArticleNumber.ToUpper(),
                            this.Context?.CurrentUser?.GetPrivileges()))
                    .WithMediaRangeModel("text/html", ApplicationSettings.Get).WithView("Index");
            }

            return this.Negotiate
                .WithModel(
                    new SuccessResult<IEnumerable<SalesArticle>>(
                        this.salesArticleProxyService.Search(resource.SearchTerm)))
                .WithMediaRangeModel("text/html", ApplicationSettings.Get).WithView("Index");
        }

        private object ReallocateSalesArticles()
        {
            var resource = this.Bind<ReallocateSalesArticlesRequestResource>();

            var privileges = this.Context.CurrentUser.GetPrivileges().ToList();
            if (!this.authorisationService.HasPermissionFor(AuthorisedAction.ReallocateSalesArticles, privileges))
            {
                return this.Negotiate.WithModel(
                    new UnauthorisedResult<ResponseModel<bool>>("You are not authorised to reallocate sales articles to a new tariff"));
            }

            return this.Negotiate
                .WithModel(
                    new SuccessResult<ResponseModel<SalesArticlesReallocator>>(
                        this.salesArticleService.Reallocate(resource.OldTariffId, resource.NewTariffId)))
                .WithMediaRangeModel("text/html", ApplicationSettings.Get).WithView("Index");
        }
    }
}
