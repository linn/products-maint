namespace Linn.Products.Service.Modules
{
    using System.Linq;

    using Linn.Common.Facade;
    using Linn.Common.Resources;
    using Linn.Products.Domain;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Facade.Services;
    using Linn.Products.Resources;
    using Linn.Products.Service.Extensions;
    using Linn.Products.Service.Models;

    using Nancy;
    using Nancy.ModelBinding;
    using Nancy.Security;

    public sealed class SaHoldStoriesModule : NancyModule
    {
        private readonly ISaHoldStoriesReportService saHoldStoriesReportService;

        private readonly IFacadeService<SaHoldStory, int, SaHoldStoryResource, SaHoldStoryResource> saHoldStoryService;

        private readonly IAuthorisationService authorisationService;

        public SaHoldStoriesModule(
            ISaHoldStoriesReportService reportService,
            IFacadeService<SaHoldStory, int, SaHoldStoryResource, SaHoldStoryResource> saHoldStoryService,
            IAuthorisationService authorisationService)
        {
            this.authorisationService = authorisationService;
            this.saHoldStoryService = saHoldStoryService;
            this.saHoldStoriesReportService = reportService;
            this.Post("/products/maint/sa-hold-stories", _ => this.AddSaHoldStory());
            this.Get("/products/maint/sa-hold-stories", parameters => this.GetSaHoldStories());
            this.Get(
                "/products/maint/sa-hold-stories/{holdStoryId}",
                parameters => this.GetSaHoldStory(parameters.holdStoryId));
            this.Put(
                "/products/maint/sa-hold-stories/{holdStoryId}",
                parameters => this.UpdateSaHoldStory(parameters.holdstoryId));
            this.Get(
                "/products/reports/sa-hold-stories-for-sales-article/{articleNumber*}",
                parameters => this.GetSaHoldStoriesForArticleNumber(parameters.articleNumber));
            this.Get(
                "/products/reports/hold-stories-for-root-product/{rootProduct*}",
                parameters => this.GetHoldStoriesForRootProduct(parameters.rootProduct));
        }

        private object GetSaHoldStories()
        {
            return this.Negotiate.WithModel(this.saHoldStoryService.GetAll())
                .WithMediaRangeModel("text/html", ApplicationSettings.Get).WithView("Index");
        }

        private object GetSaHoldStory(int id)
        {
            return this.Negotiate.WithModel(this.saHoldStoryService.GetById(id))
                .WithMediaRangeModel("text/html", ApplicationSettings.Get).WithView("Index");
        }

        private object GetSaHoldStoriesForArticleNumber(string articleNumber)
        {
            return this.Negotiate
                .WithModel(this.saHoldStoriesReportService.GetHoldStoriesForSalesArticle(articleNumber))
                .WithMediaRangeModel("text/html", ApplicationSettings.Get).WithView("Index");
        }

        private object GetHoldStoriesForRootProduct(string rootProduct)
        {
            return this.Negotiate.WithModel(this.saHoldStoriesReportService.GetHoldStoriesForRootProduct(rootProduct))
                .WithMediaRangeModel("text/html", ApplicationSettings.Get).WithView("index");
        }

        private object UpdateSaHoldStory(int holdStoryId)
        {
            this.RequiresAuthentication();

            if (!this.authorisationService.HasPermissionFor(
                    AuthorisedAction.ProductHold,
                    this.Context.CurrentUser.GetPrivileges().ToList()))
            {
                return this.Negotiate.WithModel(
                    new UnauthorisedResult<SaHoldStory>("You are not authorised to update hold stories."));
            }

            var resource = this.Bind<SaHoldStoryResource>();
            resource.Links = new[] { new LinkResource("taken-off-hold-by", this.Context.CurrentUser.GetEmployeeUri()) };

            return this.Negotiate.WithModel(this.saHoldStoryService.Update(holdStoryId, resource))
                .WithMediaRangeModel("text/html", ApplicationSettings.Get).WithView("Index");
        }

        private object AddSaHoldStory()
        {
            this.RequiresAuthentication();

            if (!this.authorisationService.HasPermissionFor(
                    AuthorisedAction.ProductHold,
                    this.Context.CurrentUser.GetPrivileges().ToList()))
            {
                return this.Negotiate.WithModel(
                    new UnauthorisedResult<SaHoldStory>("You are not authorised to create hold stories."));
            }

            var resource = this.Bind<SaHoldStoryResource>();
            resource.Links = new[] { new LinkResource("put-on-hold-by", this.Context.CurrentUser.GetEmployeeUri()) };

            return this.Negotiate.WithModel(this.saHoldStoryService.Add(resource));
        }
    }
}
