namespace Linn.Products.Service.Modules
{
    using Linn.Products.Facade.Services;
    using Linn.Products.Resources;
    using Linn.Products.Service.Models;

    using Nancy;
    using Nancy.ModelBinding;

    public sealed class WEEEReportModule : NancyModule
    {
        private readonly IWEEEReportsService weeeReportsService;

        public WEEEReportModule(IWEEEReportsService weeeReportsService)
        {
            this.weeeReportsService = weeeReportsService;
            this.Get("/products/maint/weee-reports", _ => this.GetWEEEReport());
        }

        private object GetWEEEReport()
        {
            var resource = this.Bind<WEEEReportRequestResource>();

            var results = this.weeeReportsService.GetWEEEReport(resource);

            return this.Negotiate.WithModel(results).WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }
    }
}