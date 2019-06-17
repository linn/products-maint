namespace Linn.Products.Service.Reports
{
    using Linn.Products.Facade.Services;
    using Linn.Products.Resources;
    using Linn.Products.Service.Models;

    using Nancy;
    using Nancy.ModelBinding;

    public sealed class SernosUsedOnInvoiceModule : NancyModule
    {
        private readonly ISernosUsedOnInvoiceFacade facadeService;

        public SernosUsedOnInvoiceModule(ISernosUsedOnInvoiceFacade facadeService)
        {
            this.facadeService = facadeService;
            this.Get("/products/reports/sernos-used-on-invoice", parameters => this.GetSernosUsedOnInvoice());
        }

        private object GetSernosUsedOnInvoice()
        {
            var resource = this.Bind<SernosUsedOnInvoiceReportRequestResource>();
            var results =  this.facadeService.GetReport(resource.InvoiceNumber, resource.ConsignmentNumber);
            return this.Negotiate.WithModel(results).WithMediaRangeModel("text/html", ApplicationSettings.Get).WithView("Index");
        }
    }
}