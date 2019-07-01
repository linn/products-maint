namespace Linn.Products.Service.Modules
{
    using Linn.Common.Facade;
    using Linn.Products.Domain.Linnapps;
    using Linn.Products.Facade.Services;
    using Linn.Products.Resources;
    using Linn.Products.Service.Models;

    using Nancy;
    using Nancy.ModelBinding;

    public sealed class CartonsModule : NancyModule
    {
        private readonly ICartonReportsService cartonReportsService;

        private readonly IFacadeService<CartonType, string, CartonTypeResource, CartonTypeUpdateResource> cartonTypeService;

        public CartonsModule(
            ICartonReportsService cartonReportsService,
            IFacadeService<CartonType, string, CartonTypeResource, CartonTypeUpdateResource> cartonTypeService)
        {
            this.cartonReportsService = cartonReportsService;
            this.cartonTypeService = cartonTypeService;

            this.Get("/products/reports/carton-details", _ => this.GetCartonDetails());
            this.Get("/products/maint/carton-types/{name*}", parameters => this.GetCartonType(parameters.name));
            this.Put("/products/maint/carton-types/{name*}", parameters => this.UpdateCartonType(parameters.name));
            this.Post("/products/maint/carton-types", _ => this.AddCartonType());
        }

        private object UpdateCartonType(string name)
        {
            var resource = this.Bind<CartonTypeUpdateResource>();

            var cartonResult = this.cartonTypeService.Update(name, resource);
            return this.Negotiate
                .WithModel(cartonResult)
                .WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }

        private object AddCartonType()
        {
            var resource = this.Bind<CartonTypeResource>();

            var cartonResult = this.cartonTypeService.Add(resource);
            return this.Negotiate
                .WithModel(cartonResult)
                .WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }

        private object GetCartonType(string name)
        {
            var result = this.cartonTypeService.GetById(name);
            return this.Negotiate
                .WithModel(result)
                .WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }

        private object GetCartonDetails()
        {
            var results = this.cartonReportsService.GetCartonDetails();

            return this.Negotiate
                .WithModel(results)
                .WithMediaRangeModel("text/html", ApplicationSettings.Get)
                .WithView("Index");
        }
    }
}