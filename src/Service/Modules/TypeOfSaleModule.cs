namespace Linn.Products.Service.Modules
{
    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Resources;
    using Linn.Products.Service.Models;

    using Nancy;
    using Nancy.ModelBinding;

    public sealed class TypeOfSaleModule : NancyModule
    {
        private readonly IFacadeService<TypeOfSale, string, TypeOfSaleResource> typeOfSaleService;

        public TypeOfSaleModule(IFacadeService<TypeOfSale, string, TypeOfSaleResource> typeOfSaleService)
        {
            this.typeOfSaleService = typeOfSaleService;
            this.Get("/products/maint/types-of-sale/", _ => this.GetTypesOfSale());
            this.Get("/products/maint/types-of-sale/{name}", parameters => this.GetTypeOfSaleByName(parameters.name));
            this.Put("/products/maint/types-of-sale/{name}", parameters => this.UpdateTypeOfSale(parameters.name));
            this.Post("/products/maint/types-of-sale", _ => this.AddTypeOfSale());
        }

        private object GetTypesOfSale()
        {
            var result = this.typeOfSaleService.GetAll();
            return this.Negotiate
                .WithModel(result)
                .WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }

        private object GetTypeOfSaleByName(string name)
        {
            var result = this.typeOfSaleService.GetById(name);
            return this.Negotiate
                .WithModel(result)
                .WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }

        private object UpdateTypeOfSale(string name)
        {
            var resource = this.Bind<TypeOfSaleResource>();

            var result = this.typeOfSaleService.Update(name, resource);
            return this.Negotiate
                .WithModel(result)
                .WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }

        private object AddTypeOfSale()
        {
            var resource = this.Bind<TypeOfSaleResource>();

            var result = this.typeOfSaleService.Add(resource);
            return this.Negotiate
                .WithModel(result)
                .WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }
    }
}
