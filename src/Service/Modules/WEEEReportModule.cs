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
            this.Get("/products/reports/weee", _ => this.GetWEEEReportOptions());
            this.Get("/products/reports/weee/report", _ => this.GetWEEEReport());
        }

        private object GetWEEEReportOptions()
        {
            return this.Negotiate.WithModel(ApplicationSettings.Get()).WithView("Index");
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