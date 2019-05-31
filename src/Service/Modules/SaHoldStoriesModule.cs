namespace Linn.Products.Service.Modules
{
    using Linn.Common.Facade;
    using Linn.Common.Resources;
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

        public SaHoldStoriesModule(
            ISaHoldStoriesReportService reportService,
            IFacadeService<SaHoldStory, int, SaHoldStoryResource, SaHoldStoryResource> saHoldStoryService)
        {
            this.saHoldStoryService = saHoldStoryService;
            this.saHoldStoriesReportService = reportService;
            this.Post("/products/maint/sa-hold-stories", _ => this.AddSaHoldStory());
            this.Get("/products/maint/sa-hold-stories", parameters => this.GetSaHoldStories());
            this.Get("/products/maint/sa-hold-stories/{holdStoryId}", parameters => this.GetSaHoldStory(parameters.holdStoryId));
            this.Put("/products/maint/sa-hold-stories/{holdStoryId}", parameters => this.UpdateSaHoldStory(parameters.holdstoryId));
            this.Get("/products/reports/sa-hold-stories-for-sales-article/{articleNumber*}", parameters => this.GetSaHoldStoriesForArticleNumber(parameters.articleNumber));
            this.Get("/products/reports/hold-stories-for-root-product/{rootProduct}", parameters => this.GetHoldStoriesForRootProduct(parameters.rootProduct));
        }

        private object GetSaHoldStories()
        {
            return this.Negotiate
                .WithModel(this.saHoldStoryService.GetAll())
                .WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }

        private object GetSaHoldStory(int id)
        {
            return this.Negotiate
                .WithModel(this.saHoldStoryService.GetById(id))
                .WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }

        private object GetSaHoldStoriesForArticleNumber(string articleNumber)
        {
            return this.Negotiate
                .WithModel(this.saHoldStoriesReportService.GetHoldStoriesForSalesArticle(articleNumber))
                .WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }

        private object GetHoldStoriesForRootProduct(string rootProduct)
        {
            return this.Negotiate.WithModel(this.saHoldStoriesReportService.GetHoldStoriesForRootProduct(rootProduct))
                .WithMediaRangeModel("text/html", ApplicationSettings.Get).WithView("index");
        }

        private object UpdateSaHoldStory(int holdStoryId)
        {
            this.RequiresAuthentication();
            var employeeUri = this.Context.CurrentUser.GetEmployeeUri();

            var resource = this.Bind<SaHoldStoryResource>();
            resource.Links = new[] { new LinkResource("taken-off-hold-by", employeeUri) };

            var result = this.saHoldStoryService.Update(holdStoryId, resource);

            return this.Negotiate.WithModel(result).WithModel(result)
                .WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }

        private object AddSaHoldStory()
        {
            this.RequiresAuthentication();
            var employeeUri = this.Context.CurrentUser.GetEmployeeUri();
            var resource = this.Bind<SaHoldStoryResource>();
            resource.Links = new[] { new LinkResource("put-on-hold-by", employeeUri) };

            var result = this.saHoldStoryService.Add(resource);

            return this.Negotiate.WithModel(result);
        }
    }
}
