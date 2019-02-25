namespace Linn.Products.Service.Modules
{
    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;
    using Linn.Products.Service.Models;

    using Nancy;
    using Nancy.ModelBinding;

    public sealed class VatCodeModule : NancyModule
    {
        private readonly IFacadeService<VatCode, string, VatCodeResource, VatCodeResource> vatCodeService;

        public VatCodeModule(IFacadeService<VatCode, string, VatCodeResource, VatCodeResource> vatCodeService)
        {
            this.vatCodeService = vatCodeService;
            this.Get("/products/maint/vat-codes/{code}", parameters => this.GetVatCodeByCode(parameters.code));
            this.Get("/products/maint/vat-codes/", _ => this.GetVatCodes());
            this.Put("/products/maint/vat-codes/{code}", parameters => this.UpdateSernosConfig(parameters.code));
            this.Post("/products/maint/vat-codes", _ => this.AddVatCode());
        }

        private object AddVatCode()
        {
            var resource = this.Bind<VatCodeResource>();

            var result = this.vatCodeService.Add(resource);
            return this.Negotiate.WithModel(result).WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }

        private object GetVatCodeByCode(string code)
        {
            var result = this.vatCodeService.GetById(code);
            return this.Negotiate.WithModel(result).WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }

        private object GetVatCodes()
        {
            var result = this.vatCodeService.GetAll();
            return this.Negotiate.WithModel(result).WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }

        private object UpdateSernosConfig(string code)
        {
            var resource = this.Bind<VatCodeResource>();

            var result = this.vatCodeService.Update(code, resource);
            return this.Negotiate.WithModel(result).WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }
    }
}